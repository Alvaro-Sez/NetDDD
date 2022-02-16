using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Restaurant.Business.Contracts.Domain
{
    public class RestaurantContext
    {
        public List<ClientDom> Clients { get; set; } = new List<ClientDom>();
        public List<GroupDom> Groups { get; set; } = new List<GroupDom>();

        public List<TableDom> Tables { get; set; } = new List<TableDom>();

        public void SetMesa(TableDom mesa)
        {
            Tables.Add(mesa);
        }
        public void SetGrupo(GroupDom grupo)
        {
            Groups.Add(grupo);
        }
        public void SetCliente(ClientDom cliente)
        {
            Clients.Add(cliente);
        }
    }
}
