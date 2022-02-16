using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Domain;
using VY.Restaurant.Data.Contracts.Data;
using VY.Restaurant.Data.Contracts.Data.Repositories;
using VY.Restaurant.Data.Contracts.Services;

namespace VY.Restaurant.Data.Impl.Services
{
    public class BulkDataService : IBulkDataService
    {
        private readonly IGrupoRepository _grupoRepository;

        public BulkDataService(IGrupoRepository grupoRepository)
        {
            _grupoRepository = grupoRepository;
        }
        public async Task<OperationResult> BulkData(RestaurantDom restaurant)
        {
            foreach(var group in restaurant.Groups)
            {
                GrupoEntity grupoEntity = MapGroup(group);
                _grupoRepository.Add(grupoEntity);
            }
            await _grupoRepository.SaveChanges();

            return new OperationResult();
        }

        private GrupoEntity MapGroup(GroupDom groupDom)
        {
            GrupoEntity grupoEntity = new GrupoEntity()
            {
                Id = Guid.NewGuid(),
                Codigo = groupDom.GroupCode,
                NumeroPersonas = groupDom.Clients.Count,
                HoraReserva = groupDom.Hour,
                /*Mesa = new MesaEntity()
                {
                    Id = Guid.NewGuid(),
                    Codigo = groupDom.TableAssigned.code,
                    CapacidadMax = groupDom.TableAssigned.MaxCapacity,
                    CapacidadMin = groupDom.TableAssigned.MinCapacity,
                },*/
                Clientes = groupDom.Clients.Select(client => new ClienteEntity()
                {
                    Id = Guid.NewGuid(),
                    Nombre = client.Name
                }).ToList()
            };
            return grupoEntity;
        }
    }
}
