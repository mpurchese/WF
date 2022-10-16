using WF.Domain.Entities;

namespace WF.Domain.Interfaces
{
    public interface IOrderExportService
    {
        void Export(IReadOnlyCollection<Order> orders);
    }
}
