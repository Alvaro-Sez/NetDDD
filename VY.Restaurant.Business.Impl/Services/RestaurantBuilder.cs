using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Domain;
using VY.Restaurant.Business.Contracts.Services;
using VY.Restaurant.Dtos;

namespace VY.Restaurant.Business.Impl.Services
{
    public class RestaurantBuilder : IRestaurantBuilder
    {

        public RestaurantBuilder()
        {

        }
        public RestaurantContext Build(RestaurantDto restDto)
        {
            var clients = BuildClients(restDto.Clientes);
            var groups = BuildGroups(restDto.Grupos);
            var tables = BuildTables(restDto.Mesas);
            
            RestaurantContext context = new RestaurantContext()
            {
                Clients = clients,
                Groups = groups,
                Tables = tables
            };
            return context;
        }
        
        private List<ClientDom> BuildClients (List<ClienteDto> clientsdto)
        {
            List<ClientDom> clients = new List<ClientDom>();
            
            foreach (var clientdto in clientsdto)
            {
                clients.Add(new ClientDom()
                {
                    Name = clientdto.Nombre,
                    GroupCode = clientdto.Grupo
                });
            }
            return clients;
        }

        private List<GroupDom> BuildGroups (List<GrupoDto> groupsdto)
        {
            List<GroupDom> groups = new List<GroupDom>();
            
            foreach (var grupodto in groupsdto)
            {
                groups.Add(new GroupDom()
                {
                    GroupCode = grupodto.Grupo,
                    Hour = grupodto.Hora
                });
            }
            return groups;
        }

        private List<TableDom> BuildTables (List<MesaDto> tablesdto)
        {
            List<TableDom> tables = new List<TableDom>();

            foreach (var mesadto in tablesdto)
            {
                tables.Add(new TableDom()
                {
                    code = mesadto.Codigo,
                    MaxCapacity = mesadto.MaxPersonas,
                    MinCapacity = mesadto.MinPersonas,
                });
            }
            return tables;
        }
    }
}
