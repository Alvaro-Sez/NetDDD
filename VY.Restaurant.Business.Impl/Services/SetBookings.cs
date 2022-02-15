using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Domain;
using VY.Restaurant.Business.Contracts.Services;

namespace VY.Restaurant.Business.Impl.Services
{
    public class SetBookings : ISetBookings
    {
        public SetBookings()
        {

        }
        public RestaurantDom ProcessBookings(RestaurantContext context)
        {
            List<ClientDom> clients = context.Clients;
            List<GroupDom> groups = context.Groups;
            List<TableDom> tables = context.Tables;

            SetClients(groups, clients);
            SetTables(groups, tables);

            RestaurantDom restaurantDom = new RestaurantDom() { Groups = groups};
            return restaurantDom;
        }
        private void SetClients(List<GroupDom> groups, List<ClientDom> clients)
        {
            foreach(var group in groups)
            {
                group.SetClients(clients);
            }
        }

        private void SetTables(List<GroupDom> groups, List<TableDom> tables)
        {
            foreach (var group in groups)
            {
                group.SetTable(tables); /*pregunta, no olvidar es correcto empujar logica de negocio hacia el dominio?*/
            }
        }

    }
}
