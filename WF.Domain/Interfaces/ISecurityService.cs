using WF.Domain.Entities;

namespace WF.Domain.Interfaces
{
    public interface ISecurityService
    {
        public Security Get(int securityId);
    }
}
