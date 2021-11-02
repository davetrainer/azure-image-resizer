using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

[assembly: FunctionsStartup(typeof(Azure.Image.Resizer.Functions.Startup))]

namespace Azure.Image.Resizer.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IImageResizerManager, ImageResizerManager>();
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var hostBuilderContext = builder.GetContext();

            builder.ConfigurationBuilder
            .AddJsonFile(Path.Combine(hostBuilderContext.ApplicationRootPath, "local.settings.json"), optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        }
    }
}
