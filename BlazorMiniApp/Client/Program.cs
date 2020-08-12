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

            await builder.Build().RunAsync();
        }

        private static void ConfigureService(IServiceCollection services)
        {
            services.AddOptions();
            services.AddScoped<IHttpService, HttpService>();
            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
        }
    }
}
