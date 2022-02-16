using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Domain;

namespace VY.Restaurant.Data.Contracts.Data.Repositories
{
    public interface IGrupoRepository : IRepository<GrupoEntity, Guid>
    {
        public List<GrupoEntity> ToEntity(RestaurantContext rest);
    }
}
