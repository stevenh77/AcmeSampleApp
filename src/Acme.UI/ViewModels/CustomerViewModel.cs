using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Acme.DTOs;
using Acme.UI.Events;
using Acme.UI.Services;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;
using Category = Microsoft.Practices.Prism.Logging.Category;
using Customer = Acme.UI.Models.Customer;

namespace Acme.UI.ViewModels
{
    public class CustomerViewModel : NotifyPropertyChanged
    {
        private readonly IServiceProxy services;
        private readonly ILoggerFacade logger;
        private readonly IEventAggregator eventAggregator;
        private Customer originalCustomer;

        public CustomerViewModel(
            IServiceProxy services,
            ILoggerFacade logger,
            IEventAggregator eventAggregator,
            SessionState sessionState)
        {
            if (services == null) throw new ArgumentNullException("services");
            if (logger == null) throw new ArgumentNullException("logger");
            if (eventAggregator == null) throw new ArgumentNullException("eventAggregator");
            if (sessionState == null) throw new ArgumentNullException("sessionState");

            this.services = services;
            this.logger = logger;
            this.eventAggregator = eventAggregator;

            SaveCommand = new RelayCommand(SaveCommandOnExecute);
            SetupReferenceData();
            SetupForInsertOrEdit(sessionState);
        }

        private async void SetupReferenceData()
        {
            var result = await this.services.GetReferenceData();
            Categories = new ObservableCollection<DTOs.Category>(result.Item1);
            Countries = new ObservableCollection<Country>(result.Item2);
            Genders = new ObservableCollection<Gender>(result.Item3);
        }

        private void SetupForInsertOrEdit(SessionState sessionState)
        {
            object item;
            if (sessionState.TryGetValue(StateKeys.CustomerForEdit, out item))
            {
                originalCustomer = Factory.Clone((Customer) item);
                Customer = (Customer) item;
            }
            else
            {
                // init default new Customer
                Customer = new Customer {Category = Categories[0], Country = Countries[0], Gender = Genders[2]};
            }
        }

        private async void SaveCommandOnExecute(object obj)
        {
            try
            {
                IsLoading = true;

                var result = IsInUpdateMode 
                    ? await this.services.Update(customer)
                    : await this.services.Insert(customer);
                
                if (result)
                    NavigationCommands.GoToPage.Execute(NavigationScreens.CustomerList, null);

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

        private Customer customer;
        public Customer Customer
        {
            get { return customer; }
            set
            {
                if (customer == value) return;
                customer = value;
                OnPropertyChanged("Customer");
            }
        }

        public string Title
        {
            get { return originalCustomer==null ? "INSERT CUSTOMER" : "EDIT CUSTOMER"; }
        }

        public bool IsInUpdateMode
        {
            get { return originalCustomer != null; }
        }

        public ICommand SaveCommand { get; set; }
        public ObservableCollection<DTOs.Category> Categories { get; set; }
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<Gender> Genders { get; set; }
    }
}
