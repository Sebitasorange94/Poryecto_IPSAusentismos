using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using IpsAusentismos.Infrastructure;
using IpsAusentismos.Models;
using IpsAusentismos.Services;
using Microsoft.EntityFrameworkCore;

namespace IpsAusentismos.Views.Pages
{
    public partial class EventsPage : Page
    {
        private readonly EventService _svc;
        public EventsPage()
        {
            InitializeComponent();
            _svc = ServiceLocator.EventService;
            _ = LoadAsync();
        }
        private async Task LoadAsync()
        {
            EventsGrid.ItemsSource = await _svc.GetAsync();
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(EmpId.Text, out var empId)) { MessageBox.Show("Empleado inválido"); return; }
            var typeStr = (EvtType.SelectedItem as ComboBoxItem)?.Content?.ToString();
            var valid = new[] { "Ausentismo", "Incapacidad", "Permiso", "Tarde" };
            if (typeStr == null || !valid.Contains(typeStr)) { MessageBox.Show("Tipo inválido"); return; }

            var ev = new Event
            {
                EmployeeId = empId,
                Date = EvtDate.SelectedDate ?? DateTime.Now,
                Type = Enum.Parse<EventType>(typeStr),
                Description = Desc.Text,
                CreatedByUserId = Session.CurrentUser!.Id
            };
            await _svc.CreateAsync(ev);
            await LoadAsync();
            MessageBox.Show("Evento guardado");
        }
    }
}
