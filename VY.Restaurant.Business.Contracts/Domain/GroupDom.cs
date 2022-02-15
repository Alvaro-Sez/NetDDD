using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Restaurant.Business.Contracts.Domain
{
    public class GroupDom
    {
        public TableDom TableAssigned { get; set; }
        public string GroupCode { get; set; }
        public List<ClientDom> Clients{ get; set; }
        public string Hour { get; set; }

        public void SetTable(List<TableDom> tables)
        {
            int numClients = Clients.Count;
            TableDom table = tables.Where(t => !t.Reserved && t.MaxCapacity >= numClients && t.MinCapacity <= numClients).Aggregate((t, tnext) => t.MaxCapacity - numClients < tnext.MaxCapacity - numClients ? t : tnext);
            table.Reserved = true;
            TableAssigned = table;
        }

        public void SetClients(List<ClientDom> clients)
        {
            List<ClientDom> _clients = new List<ClientDom>();

            foreach(var client in clients)
            {
                if(client.GroupCode == GroupCode)
                {
                    _clients.Add(client);
                }
            }
            Clients = _clients;
        }
    }
}
