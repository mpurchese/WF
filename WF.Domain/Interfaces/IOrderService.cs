using WF.Domain.Entities;

namespace WF.Domain.Interfaces
{
    public interface IOrderService
    {
        public IReadOnlyCollection<Order> Get();
    }
}
