using System.Windows;

namespace Acme.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootstrapper = new UiBootStrapper();
            bootstrapper.Run();
        }
    }
}
