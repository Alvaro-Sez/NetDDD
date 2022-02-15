using System;
using System.Collections.Generic;

#nullable disable

namespace VY.Restaurant.Data.Contracts.Data
{
    public partial class ClienteEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Guid IdGrupo { get; set; }

        public virtual GrupoEntity IdGrupoNavigation { get; set; }
    }
}
