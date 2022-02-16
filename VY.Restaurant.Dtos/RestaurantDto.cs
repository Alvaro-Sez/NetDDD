using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Restaurant.Dtos
{
    public class RestaurantDto
    {
        public List<ClienteDto> Clientes { get; set; } = new List<ClienteDto>();
        public List<GrupoDto> Grupos { get; set; } = new List<GrupoDto>();

        public List<MesaDto> Mesas { get; set; } = new List<MesaDto>();

        public void SetMesa(MesaDto mesa)
        {
            Mesas.Add(mesa);
        }
        public void SetGrupo(GrupoDto grupo)
        {
            Grupos.Add(grupo);
        }
        public void SetCliente(ClienteDto cliente)
        {
            Clientes.Add(cliente);
        }
    }
}
