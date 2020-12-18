using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using MVPConf.Backend;
using System.IO;
using MVPConf.Backend.Config;
using Microsoft.Extensions.DependencyInjection;
using MVPConf.Backend.Repository;
using MVPConf.Backend.Repository.Contract;
using MVPConf.Backend.Service;
using MVPConf.Backend.Service.Contract;

[assembly: FunctionsStartup(typeof(Startup))]
namespace MVPConf.Backend
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<CommonConfigurations>()
            .Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection(nameof(CommonConfigurations)).Bind(settings);
            });

            builder.Services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            builder.Services.AddScoped<ITalkRepository, TalkRepository>();
            builder.Services.AddScoped<ISpeakerService, SpeakerService>();
            builder.Services.AddScoped<ITalkService, TalkService>();
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();

            builder.ConfigurationBuilder
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, "appsettings.json"), optional: true, reloadOnChange: false)
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appsettings.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
        }
    }
}
