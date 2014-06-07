using System;
using System.Windows;
using Acme.UI.Events;
using FirstFloor.ModernUI.Windows.Controls;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;

namespace Acme.UI
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<ApplicationExceptionEvent>().Subscribe(ShowErrorDialog);
            eventAggregator.GetEvent<ConfirmationDialogEvent>().Subscribe(ShowConfirmationDialog);
        }

        private void ShowErrorDialog(string exceptionMessage)
        {
            var content = string.Format("The following exception occured: {0}{0}{1}", Environment.NewLine, exceptionMessage);
            new ModernDialog {Title = "Oops, something went wrong...", Content = content}.ShowDialog();
        }

        private void ShowConfirmationDialog(Action callback)
        {
            var result = ModernDialog.ShowMessage("Are you sure?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                callback();
        }
    }
}
