using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using IpsAusentismos.Data;
using IpsAusentismos.Infrastructure;
using IpsAusentismos.Models;
using IpsAusentismos.Services;

namespace IpsAusentismos.Views.Pages
{
    public partial class AdminPage : Page
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        private readonly PasswordService _pwd;
        public AdminPage()
        {
            InitializeComponent();
            _factory = ServiceLocator.DbFactory;
            _pwd     = ServiceLocator.Passwords;
            _ = LoadAsync();
        }
        private async Task LoadAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            UsersGrid.ItemsSource = await db.Users.Include(x => x.Role).ToListAsync();
        }
        private async void Create_Click(object sender, RoutedEventArgs e)
        {
            using var db = await _factory.CreateDbContextAsync();
            var username = (UserBox.Text ?? "").Trim();
            if (await db.Users.AnyAsync(x => x.Username == username)) { MessageBox.Show("Usuario ya existe"); return; }
            var roleId = Role.SelectedIndex switch { 0 => 1, 1 => 2, 2 => 3, _ => 3 };

            var u = new User
            {
                Username = username,
                FirstName = (NameBox.Text ?? "").Trim(),
                LastName  = (LastBox.Text ?? "").Trim(),
                RoleId = roleId,
                IsActive = true
            };
            u.PasswordHash = _pwd.Hash(u, Pwd.Password);
            db.Users.Add(u);
            await db.SaveChangesAsync();
            await LoadAsync();
            MessageBox.Show("Usuario creado");
        }
    }
}
