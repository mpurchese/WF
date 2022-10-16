using CsvHelper.Configuration;
using WF.Domain.Entities;

namespace WF.Export.Maps
{
    public class OrderMapCcc : ClassMap<Order>
    {
        public OrderMapCcc()
        {
            Map(m => m.Portfolio.PortfolioCode).Index(0).Name("PortfolioCode");
            Map(m => m.Security.Ticker).Index(1).Name("Ticker");
            Map(m => m.Nominal).Index(2).Name("Nominal");
            Map(m => m.TransactionType).Convert(r => r.Value.TransactionType[..1]).Index(3).Name("TransactionType");
        }
    }
}
