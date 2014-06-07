using Acme.UI.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Acme.UI.Views
{
    public partial class Search
    {
        public Search()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Current.GetInstance<SearchViewModel>();
        }
    }
}
