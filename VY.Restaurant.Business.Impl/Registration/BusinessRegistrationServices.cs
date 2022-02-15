using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Services;
using VY.Restaurant.Business.Impl.Services;
using VY.Restaurant.Data.Impl.Registration;

namespace VY.Restaurant.Business.Impl.Registration
{
    public static class BusinessRegistrationServices
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRestaurantBuilder, RestaurantBuilder>();
            services.AddTransient<ISetBookings, SetBookings>();
            services.AddTransient<IProcessRestaurant, ProcessRestaurant>();
            services.AddDataServices(configuration);

            return services;
        }
    }
}
