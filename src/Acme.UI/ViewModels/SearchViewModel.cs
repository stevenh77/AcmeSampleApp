using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Acme.UI.Events;
using Acme.UI.Models;
using Acme.UI.Services;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Acme.UI.ViewModels
{
    public class SearchViewModel : NotifyPropertyChanged
    {
        private readonly IServiceProxy services;
        private readonly ILoggerFacade logger; 
        private readonly IEventAggregator eventAggregator;

        public SearchViewModel(IServiceProxy services, ILoggerFacade logger, IEventAggregator eventAggregator)
        {
            if (services == null) throw new ArgumentNullException("services");
            if (logger == null) throw new ArgumentNullException("logger");
            if (eventAggregator == null) throw new ArgumentNullException("eventAggregator");

            this.services = services;
            this.logger = logger;
            this.eventAggregator = eventAggregator;

            SearchResults = new ObservableCollection<Customer>();
            SearchCommand = new RelayCommand(SearchCommandOnExecute, SearchCommandCanExecute);
        }

        private bool SearchCommandCanExecute(object o)
        {
            return searchString.Length > 0;
        }

        public async void SearchCommandOnExecute(object obj)
        {
            await SearchForCustomers();
        }

        public async Task SearchForCustomers()
        {
            try
            {
                IsLoading = true;
                SearchResults.Clear();
                
                var customers = await services.SearchForCustomers(searchString);
                
                foreach (var customer in customers)
                {
                    SearchResults.Add(customer);
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;
                ErrorMessage = ex.Message;
                logger.Log(ex.Message, Category.Exception, Priority.High);
                eventAggregator.GetEvent<ApplicationExceptionEvent>().Publish(ex.Message);
            }
        }

        private string searchString = string.Empty;
        public string SearchString
        {
            get { return searchString; }
            set
            {
                if (searchString == value) return;
                searchString = value; 
                OnPropertyChanged("SearchString");
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

        public ObservableCollection<Customer> SearchResults { get; set; }
        public ICommand SearchCommand { get; set; }
    }
}
