using CsvHelper.Configuration;
using WF.Domain.Entities;

namespace WF.Export.Maps
{
    public class OrderMapBbb : ClassMap<Order>
    {
        public OrderMapBbb()
        {
            Map(m => m.Security.CUSIP).Index(0).Name("Cusip");
            Map(m => m.Portfolio.PortfolioCode).Index(1).Name("PortfolioCode");
            Map(m => m.Nominal).Index(2).Name("Nominal");
            Map(m => m.TransactionType).Index(3).Name("TransactionType");
        }
    }
}
