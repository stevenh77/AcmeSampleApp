using System;
using System.Configuration;
using FirstFloor.ModernUI.Presentation;

namespace Acme.UI.ViewModels
{
    public class ServicesViewModel : NotifyPropertyChanged
    {
        public ServicesViewModel()
        {
            string baseServiceUrl = ConfigurationManager.AppSettings.Get("baseServiceUrl");
            Message = "This application uses the following base service url:   "
                      + baseServiceUrl
                      + Environment.NewLine
                      + Environment.NewLine
                      + "To change the base service url please update the App.config file." 
                      + Environment.NewLine
                      + Environment.NewLine
                      + "The 'useFakeData' setting is also stored in the App.config for this client application.";
        }

        private string message = string.Empty;
        public string Message
        {
            get { return message; }
            set
            {
                if (message == value) return;
                message = value;
                OnPropertyChanged("Message");
            }
        }
    }
}
