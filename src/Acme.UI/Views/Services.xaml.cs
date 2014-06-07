using Acme.UI.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Acme.UI.Views
{
    public partial class Services 
    {
        public Services()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Current.GetInstance<ServicesViewModel>();
        }
    }
}
