using System.Globalization;
using System.IO;
using IpsAusentismos.Models;

namespace IpsAusentismos.Helpers
{
    public static class CsvExporter
    {
        public static string ExportEvents(IEnumerable<Event> eventsList)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                $"reporte_eventos_{DateTime.Now:yyyyMMdd_HHmm}.csv");
            using var sw = new StreamWriter(path, false, System.Text.Encoding.UTF8);
            sw.WriteLine("EmpleadoId;Fecha;Tipo;Descripción");
            foreach (var e in eventsList)
                sw.WriteLine(string.Join(';',
                    e.EmployeeId.ToString(),
                    e.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    e.Type,
                    (e.Description ?? string.Empty).Replace(';', ',')));
            return path;
        }
    }
}
