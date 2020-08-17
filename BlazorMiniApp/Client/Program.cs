using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HttpClientService.Blazor;
using Tewr.Blazor.FileReader;
using Microsoft.JSInterop;
using System.Globalization;

namespace BlazorMiniApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            ConfigureService(builder.Services);
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var host = builder.Build();
            var js = host.Services.GetRequiredService<IJSRuntime>();
            var culture = await js.InvokeAsync<string>("blazorCulture.get");

            CultureInfo selectedCulture;
            if (culture == null)
            {
                selectedCulture = new CultureInfo("en-US");
            }
            else
            {
                selectedCulture = new CultureInfo(culture);
            }

            CultureInfo.DefaultThreadCurrentCulture = selectedCulture;
            CultureInfo.DefaultThreadCurrentUICulture = selectedCulture;

            await host.RunAsync();
        }

        private static void ConfigureService(IServiceCollection services)
        {
            services.AddOptions();
            services.AddScoped<IHttpService, HttpService>();
            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
            // Localization
            services.AddLocalization();
        }
    }
}
