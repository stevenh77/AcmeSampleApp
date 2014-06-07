using Acme.UI.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Acme.UI.Views
{
    public partial class SettingsAppearance
    {
        public SettingsAppearance()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Current.GetInstance<SettingsAppearanceViewModel>();
        }
    }
}
