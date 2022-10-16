using WF.Domain.Entities;

namespace WF.Domain.Interfaces
{
    public interface ISecurityRepository
    {
        public IReadOnlyCollection<Security> Get();
    }
}
