using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Domain;

namespace VY.Restaurant.Data.Contracts.Data.Repositories
{
    public interface IClienteRepository : IRepository<ClienteEntity, Guid>
    {
        public List<ClienteEntity> ToEntity(RestaurantContext rest);
    }
}
