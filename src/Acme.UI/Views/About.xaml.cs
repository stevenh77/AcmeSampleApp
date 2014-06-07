using Acme.UI.ViewModels;

namespace Acme.UI.Views
{
    public partial class About
    {
        public About()
        {
            InitializeComponent();
            this.DataContext = new AboutViewModel();
        }
    }
}
