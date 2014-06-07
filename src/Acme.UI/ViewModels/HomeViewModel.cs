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
using Category = Microsoft.Practices.Prism.Logging.Category;

namespace Acme.UI.ViewModels
{
    public class HomeViewModel : NotifyPropertyChanged
    {
        private readonly IServiceProxy services;
        private readonly ILoggerFacade logger;
        private readonly IEventAggregator eventAggregator;

        public HomeViewModel(IServiceProxy services, ILoggerFacade logger, IEventAggregator eventAggregator)
        {
            if (services == null) throw new ArgumentNullException("services");
            if (logger == null) throw new ArgumentNullException("logger");
            if (eventAggregator == null) throw new ArgumentNullException("eventAggregator");

            this.services = services;
            this.logger = logger;
            this.eventAggregator = eventAggregator;

            RefreshCommand = new RelayCommand(RefreshCommandOnExecute, RefreshCommandCanExecute);
            this.LoadStats();
        }

        private bool RefreshCommandCanExecute(object o)
        {
            return !this.IsLoading;
        }

        public async void RefreshCommandOnExecute(object obj)
        {
            await LoadStats();
        }

        public async Task LoadStats()
        {
            try
            {
                IsLoading = true;
                var stats = await services.GetCustomersByCategoryAndLocation();

                CategoryStats = new ObservableCollection<ChartData>(stats.Item1);
                OnPropertyChanged("CategoryStats");

                LocationStats = new ObservableCollection<ChartData>(stats.Item2);
                OnPropertyChanged("LocationStats");

                IsLoading = false;
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message, Category.Exception, Priority.High);
                eventAggregator.GetEvent<ApplicationExceptionEvent>().Publish(ex.Message);
                IsLoading = false;
                ErrorMessage = ex.Message;
            }
        }

        public ICommand RefreshCommand { get; set; }
        public ObservableCollection<ChartData> LocationStats { get; set; }
        public ObservableCollection<ChartData> CategoryStats { get; set; }

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
    }
}
