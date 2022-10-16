namespace WF.Domain.Entities
{
    public class Order
    {
        public Security Security { get; set; }
        public Portfolio Portfolio { get; set; }
        public decimal Nominal { get; set; }
        public string OMS { get; set; }
        public string TransactionType { get; set; }

        public Order(Security security, Portfolio portfolio, decimal nominal, string oms, string transactionType)
        {
            this.Security = security;
            this.Portfolio = portfolio;
            this.Nominal = nominal;
            this.OMS = oms;
            this.TransactionType = transactionType;
        }
    }
}
