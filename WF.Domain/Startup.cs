using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WF.Domain
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var assembly = Assembly.GetExecutingAssembly();
            AddSingletons(serviceCollection, assembly, "Service");
        }

        private static void AddSingletons(IServiceCollection serviceCollection, Assembly assembly, string suffix)
        {
            foreach (var implementation in assembly.GetExportedTypes().Where(t => !t.IsAbstract && t.Name.EndsWith(suffix)))
            {
                var iFace = implementation.GetInterfaces().FirstOrDefault(i => i.Name.EndsWith(suffix));
                if (iFace != null) serviceCollection.AddSingleton(iFace, implementation);
            }
        }
    }
}
