using System.Windows;
using System.Windows.Media;
using Acme.UI.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Acme.UI.Views
{
    public partial class Home
    {
        public Home()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Current.GetInstance<HomeViewModel>();
        }

        private void Home_OnLoaded(object sender, RoutedEventArgs e)
        {
            //Matrix m = PresentationSource.FromVisual(Application.Current.MainWindow).CompositionTarget.TransformToDevice;
            //double dx = m.M11;
            //double dy = m.M22;

            //ScaleTransform s = (ScaleTransform )homeContainerGrid.LayoutTransform;
            //s.ScaleX = 1 / dx;
            //s.ScaleY = 1 / dy;
        }
    }
}
