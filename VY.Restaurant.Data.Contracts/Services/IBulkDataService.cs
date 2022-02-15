using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Domain;

namespace VY.Restaurant.Data.Contracts.Services
{
    public interface IBulkDataService
    {
        Task<OperationResult> BulkData(RestaurantDom restaurant);

    }
}
