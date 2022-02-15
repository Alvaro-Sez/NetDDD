using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Domain;
using VY.Restaurant.Dtos;

namespace VY.Restaurant.Business.Contracts.Services
{
    public interface IRestaurantBuilder
    {
        public RestaurantContext Build(RestaurantDto restDto);
    }
}
