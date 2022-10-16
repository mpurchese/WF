namespace WF.Domain.Interfaces
{
    public interface IAppConfigService
    {
        string ExportFolder { get; }
        string PortfoliosPath { get; }
        string SecuritiesPath { get; }
        string TransactionsPath { get; }
    }
}
