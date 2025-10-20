using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using IpsAusentismos.Models;
using IpsAusentismos.Services;

namespace IpsAusentismos.Views.Pages
{
    public partial class ReportsPage : Page
    {
        private readonly EventService _svc;
        private List<Event> _cache = new();
        public ReportsPage()
        {
            InitializeComponent();
            _svc = Infrastructure.ServiceLocator.EventService;
        }
        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            EventType? t = null;
            var sel = (Type.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (!string.IsNullOrWhiteSpace(sel) && sel != "(Todos)") t = Enum.Parse<EventType>(sel!);
            _cache = await _svc.GetAsync(From.SelectedDate, To.SelectedDate, t);
            ReportsGrid.ItemsSource = _cache;
        }
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var path = Helpers.CsvExporter.ExportEvents(_cache);
            MessageBox.Show($"Exportado en: {path}");
        }
    }
}
