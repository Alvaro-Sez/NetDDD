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
    public class MesaRepository : BaseRepository<RestaurantDbContext, MesaEntity, Guid>, IMesaRepository
    {
        public MesaRepository(RestaurantDbContext context) : base(context)
        {
        }

        public List<MesaEntity> ToEntity(RestaurantContext rest)
        {
            List<MesaEntity> mesaEntities = new List<MesaEntity>();
            foreach (var table in rest.Tables)
            {
                var entity = new MesaEntity()
                {
                    Id = Guid.NewGuid(),
                    CapacidadMax = table.MaxCapacity,
                    CapacidadMin = table.MinCapacity,
                    Codigo = table.code
                };
                mesaEntities.Add(entity);
            }
            return mesaEntities;
        }
    }
}
