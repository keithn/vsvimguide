using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VsVimGuide
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole())
                .AddScoped<App>();
            using (var provider = services.BuildServiceProvider())
            using (var app = provider.GetService<App>())
            {
                app.Run();
            }
        }
    }
}
