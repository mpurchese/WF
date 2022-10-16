using CsvHelper.Configuration;
using WF.Domain.Entities;

namespace WF.Export.Maps
{
    public class OrderMapAaa : ClassMap<Order>
    {
        public OrderMapAaa()
        {
            Map(m => m.Security.ISIN).Index(0).Name("ISIN");
            Map(m => m.Portfolio.PortfolioCode).Index(1).Name("PortfolioCode");
            Map(m => m.Nominal).Index(2).Name("Nominal");
            Map(m => m.TransactionType).Index(3).Name("TransactionType");
        }
    }
}
