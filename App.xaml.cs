using System.Windows;
using IpsAusentismos.Infrastructure;

namespace IpsAusentismos
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Configuration.Load();
            var win = new Views.Windows.LoginWindow();
            win.Show();
        }
    }
}
