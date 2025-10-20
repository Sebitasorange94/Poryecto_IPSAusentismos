using System.Windows;
using System.Windows.Controls; 

namespace IpsAusentismos.Views.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Infrastructure.Session.CurrentUser == null)
                {
                    var login = new Views.Windows.LoginWindow();
                    Application.Current.MainWindow = login;
                    login.Show();
                    this.Close();
                    return;
                }
            SafeNavigate(() => new Views.Pages.DashboardPage());
        }
        private void SafeNavigate(Func<Page> targetFactory)
        {
            try { MainFrame.Navigate(targetFactory()); }
            catch (Exception ex) { MessageBox.Show("No se pudo abrir la vista: " + ex.Message); }
        }
        private void NavDashboard(object s, RoutedEventArgs e) => SafeNavigate(() => new Views.Pages.DashboardPage());
        private void NavEvents(object s, RoutedEventArgs e) => SafeNavigate(() => new Views.Pages.EventsPage());
        private void NavReports(object s, RoutedEventArgs e) => SafeNavigate(() => new Views.Pages.ReportsPage());
        private void NavVacations(object s, RoutedEventArgs e) => SafeNavigate(() => new Views.Pages.VacationsPage());
        private void NavAdmin(object s, RoutedEventArgs e) => SafeNavigate(() => new Views.Pages.AdminPage());
        private void NavLogout(object s, RoutedEventArgs e)
        {
            // Limpiar sesión
            Infrastructure.Session.Clear();

            // Mostrar ventana de Login de nuevo
            var login = new Views.Windows.LoginWindow();
            Application.Current.MainWindow = login;
            login.Show();

            // Cerrar la ventana principal actual
            this.Close();
        }
       

    }
}
