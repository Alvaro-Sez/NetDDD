using System;
using System.Collections.Generic;

#nullable disable

namespace VY.Restaurant.Data.Contracts.Data
{
    public partial class MesaEntity
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public int CapacidadMax { get; set; }
        public int CapacidadMin { get; set; }
    }
}
