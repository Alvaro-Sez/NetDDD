using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Domain;
using VY.Restaurant.Data.Contracts.Data;
using VY.Restaurant.Data.Contracts.Data.Repositories;

namespace VY.Restaurant.Data.Impl.Data.Repositories
{
    public class ClienteRepository : BaseRepository<RestaurantDbContext, ClienteEntity, Guid>, IClienteRepository
    {
        public ClienteRepository(RestaurantDbContext context) : base(context)
        {
        }

        public List<ClienteEntity> ToEntity(RestaurantContext rest)
        {
            List<ClienteEntity> clienteEntities = new List<ClienteEntity>();
            foreach (var client in rest.Clients)
            {
                var entity = new ClienteEntity()
                {
                    Id = Guid.NewGuid(),
                    Nombre = client.Name,
                };
                clienteEntities.Add(entity);
            }
            return clienteEntities;
        }
    }
}
