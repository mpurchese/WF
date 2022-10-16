using CsvHelper;
using System.Globalization;
using WF.Domain.Entities;
using WF.Domain.Interfaces;

namespace WF.Data.Implementation
{
    public class TransactionRepository : ITransactionRepository
    { 
        private readonly string importPath;

        public TransactionRepository(IAppConfigService appConfigService)
        {
            this.importPath = appConfigService.TransactionsPath;
        }

        public IReadOnlyCollection<Transaction> Get()
        {
            if (!File.Exists(this.importPath)) throw new Exception("Transactions not found in path: " + this.importPath);

            using var reader = new StreamReader(this.importPath);
            using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
            return csv.GetRecords<Transaction>().ToList();
        }
    }
}
