using System;
using System.Collections.Generic;

#nullable disable

namespace VY.Restaurant.Data.Contracts.Data
{
    public partial class GrupoEntity
    {
        public GrupoEntity()
        {
            Clientes = new HashSet<ClienteEntity>();
        }

        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public int? NumeroPersonas { get; set; }
        public string HoraReserva { get; set; }

        public virtual ICollection<ClienteEntity> Clientes { get; set; }
    }
}
