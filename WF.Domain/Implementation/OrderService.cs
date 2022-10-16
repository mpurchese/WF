using WF.Domain.Entities;
using WF.Domain.Interfaces;

namespace WF.Domain.Implementation
{
    public class OrderService : IOrderService
    {        
        private readonly IPortfolioRepository portfolioRepository;
        private readonly ISecurityRepository securityRepository;
        private readonly ITransactionRepository transactionRepository;

        public OrderService(IPortfolioRepository portfolioRepository, ISecurityRepository securityRepository, ITransactionRepository transactionRepository)
        {
            this.portfolioRepository = portfolioRepository;
            this.securityRepository = securityRepository;
            this.transactionRepository = transactionRepository;
        }

        public IReadOnlyCollection<Order> Get()
        {
            // Static data - in a real app we would want to cache this, probably - but keep it simple for now!
            var portfolios = this.portfolioRepository.Get().ToDictionary(p => p.PortfolioId, p => p);
            var securities = this.securityRepository.Get().ToDictionary(s => s.SecurityId, s => s);

            var transactions = this.transactionRepository.Get();

            var orders = new List<Order>();

            foreach (var transaction in transactions)
            {
                if (!portfolios.TryGetValue(transaction.PortfolioId, out var portfolio))
                {
                    // TODO: Invalid portfolio!  Tell someone!
                    continue;
                }

                if (!securities.TryGetValue(transaction.SecurityId, out var security))
                {
                    // TODO: Invalid security!  Tell someone!
                    continue;
                }

                if (transaction.OMS == null)
                {
                    // TODO: Validate that this is a recognised OMS
                    // TODO: Exception handling
                    continue;
                }

                if (transaction.TransactionType == null)
                {
                    // TODO: Validate that this is a recognised TransactionType (BUY/SELL)
                    // TODO: Exception handling
                    continue;
                }

                orders.Add(new Order(security, portfolio, transaction.Nominal, transaction.OMS, transaction.TransactionType));
            }

            return orders;
        }
    }
}
