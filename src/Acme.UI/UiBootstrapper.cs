using System;
using System.Configuration;
using System.Windows;
using Acme.UI.Infrastructure;
using Acme.UI.Services;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Acme.UI
{
    public class UiBootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();

            SetupReferenceData();
        }

        private async void SetupReferenceData()
        {
            // actually this reference data in fake and real service proxies both return fake data refactor later
            var data = await ServiceLocator.Current.GetInstance<ServiceProxy>().GetReferenceData();
            var session = ServiceLocator.Current.GetInstance<SessionState>();
            session.AddOrUpdate(StateKeys.CategoryData, data.Item1, (key, oldValue) => data.Item1);
            session.AddOrUpdate(StateKeys.CountryData, data.Item1, (key, oldValue) => data.Item2);
            session.AddOrUpdate(StateKeys.GenderData, data.Item1, (key, oldValue) => data.Item3);

        }

        protected override ILoggerFacade CreateLogger()
        {
            return new DebugLogger();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // VERY IMPORTANT:  if the app.config says to use fake data we register the FakeServiceProxy 
            var useFakeData = Convert.ToBoolean(ConfigurationManager.AppSettings["useFakeData"]);
            RegisterTypeIfMissing(typeof(IServiceProxy), useFakeData ? typeof(FakeServiceProxy) : typeof(ServiceProxy), true);

            // Event Aggregator for pub/sub
            RegisterTypeIfMissing(typeof(IEventAggregator), typeof(EventAggregator), true);

            // Session State object for help navigation (this could be refactored to move navigation to purely pub/sub with messages)
            RegisterTypeIfMissing(typeof(SessionState), typeof(SessionState), true);

            // registering the container to the service locator singleton
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(this.Container));
        }
    }
}
