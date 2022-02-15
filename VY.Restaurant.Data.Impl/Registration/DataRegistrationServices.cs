using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Data.Contracts.Data.Repositories;
using VY.Restaurant.Data.Contracts.Services;
using VY.Restaurant.Data.Impl.Data;
using VY.Restaurant.Data.Impl.Data.Repositories;
using VY.Restaurant.Data.Impl.Services;

namespace VY.Restaurant.Data.Impl.Registration
{
    public static class DataRegistrationServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextPool<RestaurantDbContext>((provider, builder) =>
            {
                builder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                builder.UseSqlServer(configuration.GetConnectionString("Restaurante"));
            });


            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IMesaRepository, MesaRepository>();
            services.AddTransient<IGrupoRepository, GrupoRepository>();

            services.AddTransient<IBulkDataService, BulkDataService>();
            return services;
        }
    }
}
