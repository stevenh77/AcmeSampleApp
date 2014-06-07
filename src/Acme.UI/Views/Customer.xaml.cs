using Acme.UI.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Acme.UI.Views
{
    public partial class Customer 
    {
        public Customer()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Current.GetInstance<CustomerViewModel>();
        }
    }
}
