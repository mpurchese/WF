using CsvHelper;
using System.Globalization;
using WF.Domain.Entities;
using WF.Domain.Interfaces;

namespace WF.Data.Implementation
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly string importPath;

        public PortfolioRepository(IAppConfigService appConfigService)
        {
            this.importPath = appConfigService.PortfoliosPath;
        }

        public IReadOnlyCollection<Portfolio> Get()
        {
            if (!File.Exists(this.importPath)) throw new Exception("Portfolios not found in path: " + this.importPath);

            using var reader = new StreamReader(this.importPath);
            using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
            return csv.GetRecords<Portfolio>().ToList();
        }
    }
}
