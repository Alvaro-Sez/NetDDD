using System;
using VY.Restaurant.Data.Contracts.Data;
using VY.Restaurant.Data.Contracts.Data.Repositories;

namespace VY.Restaurant.Data.Impl.Data.Repositories
{
    public class GrupoRepository : BaseRepository<RestaurantDbContext, GrupoEntity, Guid>, IGrupoRepository
    {
        public GrupoRepository(RestaurantDbContext context) : base(context)
        {
        }
    }
}
