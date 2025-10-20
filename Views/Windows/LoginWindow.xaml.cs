using System.Windows;
using IpsAusentismos.Infrastructure;

namespace IpsAusentismos.Views.Windows
{
    public partial class LoginWindow : Window
    {
        private readonly Services.UserService _users;
        public LoginWindow()
        {
            InitializeComponent();
            _users = ServiceLocator.UserService;
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var u = await _users.LoginAsync(UserBox.Text.Trim(), PwdBox.Password);
                if (u == null)
                {
                    MessageBox.Show("Credenciales inválidas", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Session.SetUser(u);
                var mw = new MainWindow();
                mw.Show();
                this.Hide(); // primero ocultar
                this.Close(); // cerrar cuando ya abrió
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión:\n" + ex.Message, "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
