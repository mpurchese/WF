using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using WF.Domain.Entities;
using WF.Domain.Enumeration;
using WF.Domain.Interfaces;

namespace WF.Export.Maps
{
    public class OrderExportService : IOrderExportService
    {
        private readonly string exportPath;

        public OrderExportService(IAppConfigService appConfigService)
        {
            this.exportPath = appConfigService.ExportFolder;
        }

        public void Export(IReadOnlyCollection<Order> transactions)
        {
            this.ExportAaa(transactions.Where(t => t.OMS == OMS.AAA).ToList());
            this.ExportBbb(transactions.Where(t => t.OMS == OMS.BBB).ToList());
            this.ExportCcc(transactions.Where(t => t.OMS == OMS.CCC).ToList());
        }

        private void ExportAaa(IReadOnlyCollection<Order> transactions)
        {
            if (!transactions.Any()) return;

            // TODO: File name may not be unique!
            var file = Path.Combine(this.exportPath, $"{DateTime.Now:yyyyMMddHHmmss}.aaa");

            using var writer = new StreamWriter(file);
            using var csv = new CsvWriter(writer, CultureInfo.CurrentCulture);
            csv.Context.RegisterClassMap<OrderMapAaa>();
            csv.WriteRecords(transactions);
        }

        private void ExportBbb(IReadOnlyCollection<Order> transactions)
        {
            if (!transactions.Any()) return;

            var file = Path.Combine(this.exportPath, $"{DateTime.Now:yyyyMMddHHmmss}.bbb");

            using var writer = new StreamWriter(file);
            var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = "|" };
            using var csv = new CsvWriter(writer, config);            
            csv.Context.RegisterClassMap<OrderMapBbb>();
            csv.WriteRecords(transactions);
        }

        private void ExportCcc(IReadOnlyCollection<Order> transactions)
        {
            if (!transactions.Any()) return;

            var file = Path.Combine(this.exportPath, $"{DateTime.Now:yyyyMMddHHmmss}.ccc");

            using var writer = new StreamWriter(file);
            var config = new CsvConfiguration(CultureInfo.CurrentCulture) { HasHeaderRecord = false };
            using var csv = new CsvWriter(writer, config);
            csv.Context.RegisterClassMap<OrderMapCcc>();
            csv.WriteRecords(transactions);
        }
    }
}
