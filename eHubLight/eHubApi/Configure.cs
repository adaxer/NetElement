using NLog.Config;
using NLog.Targets;
using NLog.Web;
using NLog;
using Microsoft.AspNetCore.Mvc.Formatters;
using eHubApi.Middleware;

namespace eHubApi;

internal static class Configure
{
    internal static void ConfigureApp(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseMyRequestLogging();
        app.MapControllers();
    }

    internal static void ConfigureBuilder(WebApplicationBuilder builder)
    {

        builder.Services.AddControllers(o=>
        {
            o.OutputFormatters.Add(new XmlSerializerOutputFormatter());
        });


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

       ConfigureNLog(builder);
    }

    private static void ConfigureNLog(WebApplicationBuilder builder)
    {
        // Initialize NLog configuration
        var config = new LoggingConfiguration();

        // Define the target
        var consoleTarget = new ColoredConsoleTarget("console")
        {
            Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}"
        };

        config.AddTarget(consoleTarget);

        // Define rules
        config.AddRuleForAllLevels(consoleTarget);

        // Apply config
        LogManager.Configuration = config;

        // Configure NLog as the logging provider
        builder.Logging.ClearProviders();
        builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
        builder.Host.UseNLog();
    }
}
