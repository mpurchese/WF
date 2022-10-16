using CsvHelper;
using System.Globalization;
using WF.Domain.Entities;
using WF.Domain.Interfaces;

namespace WF.Data.Implementation
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly string importPath;

        public SecurityRepository(IAppConfigService appConfigService)
        {
            this.importPath = appConfigService.SecuritiesPath;
        }

        public IReadOnlyCollection<Security> Get()
        {
            if (!File.Exists(this.importPath)) throw new Exception("Securities not found in path: " + this.importPath);

            using var reader = new StreamReader(this.importPath);
            using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
            return csv.GetRecords<Security>().ToList();
        }
    }
}
