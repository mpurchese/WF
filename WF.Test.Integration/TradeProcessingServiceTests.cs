using Microsoft.Extensions.DependencyInjection;
using Moq;
using WF.Domain.Interfaces;

namespace WF.Test
{
    [TestClass]
    public class TradeProcessingServiceTests
    {
        // Populated by MSTest
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestEndToEnd()
        {
            var serviceProvider = ConfigureServices();

            var tradeProcessingService = serviceProvider.GetRequiredService<ITradeProcessingService>();

            tradeProcessingService.ProcessTransactions();

            // Should now have 3 files in the temporary test output folder
            var resultsDir = new DirectoryInfo(TestContext.TestResultsDirectory);
            Assert.AreEqual(3, resultsDir.GetFiles().Length);

            // For this excercise we would like to actually see the generated files!  Copy them to the TestResults folder.
            var parentResultsFolder = Path.GetDirectoryName(TestContext.TestDir);
            var finalFolder = new DirectoryInfo(parentResultsFolder);    // Should be {solutionDir}\TestResults
            foreach (var fileInfo in resultsDir.GetFiles())
            {
                var dest = Path.Combine(finalFolder.FullName, fileInfo.Name);
                File.Copy(fileInfo.FullName, dest, true);
            }
        }

        private ServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            Data.Startup.ConfigureServices(serviceCollection);
            Domain.Startup.ConfigureServices(serviceCollection);
            Export.Startup.ConfigureServices(serviceCollection);

            // Config folders
            var portfoliosPath = Path.Combine(TestContext.DeploymentDirectory, "Samples", "portfolios.csv");
            var securitiesPath = Path.Combine(TestContext.DeploymentDirectory, "Samples", "securities.csv");
            var transactionsPath = Path.Combine(TestContext.DeploymentDirectory, "Samples", "transactions.csv");

            // Config service
            var configService = new Mock<IAppConfigService>();
            configService.Setup(c => c.ExportFolder).Returns(TestContext.TestResultsDirectory);
            configService.Setup(c => c.PortfoliosPath).Returns(portfoliosPath);
            configService.Setup(c => c.SecuritiesPath).Returns(securitiesPath);
            configService.Setup(c => c.TransactionsPath).Returns(transactionsPath);

            serviceCollection.AddSingleton(configService.Object);

            return serviceCollection.BuildServiceProvider();
        }
    }
}