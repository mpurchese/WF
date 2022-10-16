using WF.Domain.Interfaces;

namespace WF.Domain.Implementation
{
    public class TradeProcessingService : ITradeProcessingService
    {
        private readonly IOrderExportService orderExportService;
        private readonly IOrderService orderService;

        public TradeProcessingService(IOrderExportService orderExportService, IOrderService orderService)
        {
            this.orderExportService = orderExportService;
            this.orderService = orderService;
        }

        public void ProcessTransactions()
        {
            var orders = this.orderService.Get();
            this.orderExportService.Export(orders);
        }
    }
}
