using System;
using System.Windows;
using System.Windows.Controls;
using IpsAusentismos.Models;
using IpsAusentismos.Services;

namespace IpsAusentismos.Views.Pages
{
    public partial class VacationsPage : Page
    {
        private readonly VacationService _svc;
        public VacationsPage()
        {
            InitializeComponent();
            _svc = Infrastructure.ServiceLocator.VacationService;
        }
        private async void Create_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(EmpId.Text, out var empId)) { MessageBox.Show("Empleado inválido"); return; }
            var v = new Vacation
            {
                EmployeeId = empId,
                StartDate = Start.SelectedDate ?? DateTime.Now,
                EndDate = End.SelectedDate ?? DateTime.Now.AddDays(5)
            };
            await _svc.CreateAsync(v);
            MessageBox.Show("Solicitud registrada");
        }
    }
}
