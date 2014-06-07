using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Acme.UI.Events;
using Acme.UI.Infrastructure;
using Acme.UI.Models;
using Acme.UI.Services;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;
using MoreLinq;

namespace Acme.UI.ViewModels
{
    public class MaintenanceViewModel : NotifyPropertyChanged
    {
        private readonly IServiceProxy services;
        private readonly ILoggerFacade logger;
        private readonly IEventAggregator eventAggregator;
        private readonly SessionState sessionState;

        public MaintenanceViewModel(
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
            this.sessionState = sessionState;

            this.RefreshCommand = new RelayCommand(RefreshCommandOnExecute, RefreshCommandCanExecute);
            this.InsertCommand = new RelayCommand(InsertCommandOnExecute);
            this.EditCommand = new RelayCommand(EditCommandOnExecute, EditAndDeleteCommandCanExecute);
            this.DeleteCommand = new RelayCommand(DeleteCommandOnExecute, EditAndDeleteCommandCanExecute);

            this.Customers = new ObservableCollection<Customer>();
            this.LoadCustomers();
        }

        private bool EditAndDeleteCommandCanExecute(object o)
        {
            return this.SelectedItem!=null;
        }

        public void InsertCommandOnExecute(object obj)
        {
            object ignore;
            this.sessionState.TryRemove(StateKeys.CustomerForEdit, out ignore);
            NavigationCommands.GoToPage.Execute(NavigationScreens.CustomerDetail, null);
        }

        public void EditCommandOnExecute(object obj)
        {
            this.sessionState.AddOrUpdate(StateKeys.CustomerForEdit, SelectedItem, (key, oldValue) => SelectedItem);
            NavigationCommands.GoToPage.Execute(NavigationScreens.CustomerDetail, null);
        }

        private bool RefreshCommandCanExecute(object o)
        {
            return !this.IsLoading;
        }

        public async void RefreshCommandOnExecute(object obj)
        {
            await LoadCustomers();
        }

        public async void DeleteCommandOnExecute(object obj)
        {
            if (SelectedItem == null) return;

            eventAggregator.GetEvent<ConfirmationDialogEvent>().Publish(async () =>
            {
                try
                {
                    IsLoading = true;

                    var result = await this.services.Delete(SelectedItem.Id);
                    if (!result) return;
                    Customers.Remove(SelectedItem);
                    SelectedItem = null;

                    IsLoading = false;
                }
                catch (Exception ex)
                {
                    logger.Log(ex.Message, Category.Exception, Priority.High);
                    eventAggregator.GetEvent<ApplicationExceptionEvent>().Publish(ex.Message);
                    IsLoading = false;
                    ErrorMessage = ex.Message;
                }
            });
        }
        
        public async Task LoadCustomers()
        {
            try
            {
                IsLoading = true;
                this.Customers.Clear();
                
                var customers = await services.GetAllCustomers();
                var batches = customers.Take(25).Batch(50);
                
                foreach (var batch in batches)
                    this.Customers.AddRange(batch);

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

        private Customer selectedItem;
        public Customer SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem == value) return;
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public ObservableCollection<Customer> Customers { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}
