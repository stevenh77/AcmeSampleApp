using Acme.UI.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Acme.UI.Views
{
    public partial class Audit
    {
        public Audit()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Current.GetInstance<AuditViewModel>();
        }
    }
}
