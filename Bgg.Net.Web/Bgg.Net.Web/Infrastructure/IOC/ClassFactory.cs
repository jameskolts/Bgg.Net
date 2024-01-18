using Bgg.Net.Web.Client.Models;
using Bgg.Net.Web.Services;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

namespace Bgg.Net.Web.Infrastructure.IOC
{
    public static class ClassFactory
    {
        public static WebApplicationBuilder RegisterWebComponents(this WebApplicationBuilder builder)
        {
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<AppState>();
            builder.Services.AddScoped<IBggLoginCookieService, BggLoginCookieService>();
            builder.Services.AddBlazorise(o =>
            {
                o.Immediate = true;
            });
            builder.Services.AddBootstrapProviders();
            builder.Services.AddFontAwesomeIcons();

            return builder;
        }

        public static IServiceCollection ConfigureLogging(this IServiceCollection services)
        {
            //var levelSwitch = new LoggingLevelSwitch();

            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.ControlledBy(levelSwitch)
            //    .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
            //    .WriteTo.Console()
            //    .CreateLogger();

            services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));

            services.AddLogging(builder =>
                builder.SetMinimumLevel(LogLevel.Trace));

            return services;
        }
    }
}
