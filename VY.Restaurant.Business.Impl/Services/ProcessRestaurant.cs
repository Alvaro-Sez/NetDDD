using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Domain;
using VY.Restaurant.Business.Contracts.Services;
using VY.Restaurant.Dtos;

namespace VY.Restaurant.Business.Impl.Services
{
    public class ProcessRestaurant : IProcessRestaurant
    {
        private readonly IRestaurantBuilder _builder;
        private readonly ISetBookings _setter;

        public ProcessRestaurant(IRestaurantBuilder builder, ISetBookings setter)
        {
            _builder = builder;
            _setter = setter;
        }

        public RestaurantDom Process(RestaurantDto restaurantDto)
        {
            RestaurantContext ctx = _builder.Build(restaurantDto);
            RestaurantDom restaurantDom = _setter.ProcessBookings(ctx);
            return restaurantDom;
        }
    }
}
