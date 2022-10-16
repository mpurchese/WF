using WF.Domain.Entities;

namespace WF.Domain.Interfaces
{
    public interface IPortfolioRepository
    {
        public IReadOnlyCollection<Portfolio> Get();
    }
}
