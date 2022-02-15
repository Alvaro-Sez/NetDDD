using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Restaurant.Business.Contracts.Domain
{
    public class RestaurantContext
    {
        public List<ClientDom> Clients { get; set; }
        public List<GroupDom> Groups { get; set; }

        public List<TableDom> Tables { get; set; }
    }
}
