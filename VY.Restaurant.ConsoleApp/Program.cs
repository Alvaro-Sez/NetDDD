using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Services;
using VY.Restaurant.Business.Impl.Registration;
using VY.Restaurant.Data.Contracts.Services;
using VY.Restaurant.Data.Impl.Registration;
using VY.Restaurant.Dtos;

namespace VY.Restaurant.ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
         
            DeserializerCSV deserializer = new DeserializerCSV();
            deserializer.ToClienteDto(@"CSVFiles\Clientes.csv");
            deserializer.ToGrupoDto(@"CSVFiles\Grupos.csv");
            deserializer.ToMesaDto(@"CSVFiles\Mesas.csv");
            RestaurantDto restaurantDto = deserializer.GetDtos();

            var ProcessRestaurant = host.Services.GetService<IProcessRestaurant>();
            
            var restaurantDom = ProcessRestaurant.Process(restaurantDto);

            await using (var scope = host.Services.CreateAsyncScope())
            {
                var bulkService = scope.ServiceProvider.GetRequiredService<IBulkDataService>();
                await bulkService.BulkData(restaurantDom);
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                        .ConfigureAppConfiguration((hostContext, config) =>
                        {
                            config.AddJsonFile(Path.Combine(Path.Combine(hostContext.HostingEnvironment.ContentRootPath, "Configuration"), "settings.json"));
                            config.AddEnvironmentVariables();
                            if (args != null)
                                config.AddCommandLine(args);

                        })
                        .ConfigureServices((hostContext, services) =>
                        {
                            services.AddBusinessServices(hostContext.Configuration);
                        })
                        .ConfigureLogging((hostContext, logging) =>
                        {
                            logging.AddConsole();
                        });
        }
    }
}
