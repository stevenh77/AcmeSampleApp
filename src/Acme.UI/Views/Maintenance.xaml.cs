using System.Windows.Input;
using Acme.UI.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Acme.UI.Views
{
    public partial class Maintenance
    {
        public Maintenance()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Current.GetInstance<MaintenanceViewModel>();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((MaintenanceViewModel)this.DataContext).EditCommand.Execute(null);
        }
    }
}
