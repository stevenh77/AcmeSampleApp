using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Acme.DTOs;
using Acme.UI.Events;
using Acme.UI.Services;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Acme.UI.ViewModels
{
    public class AuditViewModel : NotifyPropertyChanged
    {
        private readonly IServiceProxy services;
        private readonly ILoggerFacade logger;
        private readonly IEventAggregator eventAggregator;

        public AuditViewModel(IServiceProxy services, ILoggerFacade logger, IEventAggregator eventAggregator)
        {
            if (services == null) throw new ArgumentNullException("services");
            if (logger == null) throw new ArgumentNullException("logger");
            if (eventAggregator == null) throw new ArgumentNullException("eventAggregator");

            this.services = services;
            this.logger = logger;
            this.eventAggregator = eventAggregator;

            CustomerAudits = new ObservableCollection<CustomerAudit>();
            this.RefreshCommand = new RelayCommand(RefreshCommandOnExecute, RefreshCommandCanExecute);
            LoadAudits();
        }

        private bool RefreshCommandCanExecute(object o)
        {
            return !this.IsLoading;
        }

        public async void RefreshCommandOnExecute(object obj)
        {
            await LoadAudits();
        }

        public async Task LoadAudits()
        {
            try
            {
                IsLoading = true;
                CustomerAudits.Clear();

                var customerAudits = await services.GetAllCustomerAudits();

                foreach (var audit in customerAudits)
                {
                    CustomerAudits.Add(audit);
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message, Microsoft.Practices.Prism.Logging.Category.Exception, Priority.High);
                eventAggregator.GetEvent<ApplicationExceptionEvent>().Publish(ex.Message);
                IsLoading = false;
                ErrorMessage = ex.Message;
            }
        }

        private string errorMessage = string.Empty;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage == value) return;
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                if (isLoading == value) return;
                isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public ObservableCollection<CustomerAudit> CustomerAudits { get; set; }
        public ICommand RefreshCommand { get; set; }

    }
}