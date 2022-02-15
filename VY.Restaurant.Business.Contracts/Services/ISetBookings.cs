using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Domain;

namespace VY.Restaurant.Business.Contracts.Services
{
    public interface ISetBookings
    {
        RestaurantDom ProcessBookings(RestaurantContext context); 
    }
}
