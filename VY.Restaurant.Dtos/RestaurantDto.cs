using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Restaurant.Dtos
{
    public class RestaurantDto
    {
        public List<ClienteDto> Clientes { get; set; }
        public List<GrupoDto> Grupos { get; set; }

        public List<MesaDto> Mesas { get; set; }

    }
}
