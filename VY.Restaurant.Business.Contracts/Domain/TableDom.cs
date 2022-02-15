using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Restaurant.Business.Contracts.Domain
{
    public class TableDom
    {
        public string code { get; set; }
        public int MinCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public bool Reserved { get; set; } = false;
        
    }
}
