using System;
using System.Collections.Generic;
using VY.Restaurant.Business.Contracts.Domain;
using VY.Restaurant.Data.Contracts.Data;
using VY.Restaurant.Data.Contracts.Data.Repositories;

namespace VY.Restaurant.Data.Impl.Data.Repositories
{
    public class GrupoRepository : BaseRepository<RestaurantDbContext, GrupoEntity, Guid>, IGrupoRepository
    {
        public GrupoRepository(RestaurantDbContext context) : base(context)
        {
        }

        public List<GrupoEntity> ToEntity(RestaurantContext rest)
        {
            List<GrupoEntity> grupoEntities = new List<GrupoEntity>();
            foreach (var grupo in rest.Groups)
            {
                var entity = new GrupoEntity()
                {
                    Id = Guid.NewGuid(),
                    Codigo = grupo.GroupCode,
                    HoraReserva = grupo.Hour,
                };
                grupoEntities.Add(entity);
            }
            return grupoEntities;
        }
    }
}
