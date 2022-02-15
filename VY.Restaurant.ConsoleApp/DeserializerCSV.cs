using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Restaurant.Dtos;

namespace VY.Restaurant.ConsoleApp
{
    internal class DeserializerCSV
    {
        private readonly string _projectDirectory;
        private readonly RestaurantDto _dto = new RestaurantDto();
        public DeserializerCSV()
        {
            _projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        }

        public void ToGrupoDto(string pathCSV)
        {
            string[] grupos  = File.ReadAllLines(Path.Combine(_projectDirectory, pathCSV));
            List<GrupoDto> grupList = new List<GrupoDto>();

            for (int i = 1; i < grupos.Length; i++)
            {
                string[] rowData = grupos[i].Split(',');
                GrupoDto grupoDto = new GrupoDto
                {
                    Grupo = rowData[0],
                    NumPersonas = Convert.ToInt32(rowData[1]),
                    Hora = rowData[2]
                };
                grupList.Add(grupoDto);
            }
            _dto.Grupos = grupList;
        }

        public void ToClienteDto (string pathCSV)
        {
            string[] clientes  = File.ReadAllLines(Path.Combine(_projectDirectory, pathCSV));
            List<ClienteDto> clienteList = new List<ClienteDto>();

            for (int i = 1; i < clientes.Length; i++)
            {
                string[] rowData = clientes[i].Split(',');
                ClienteDto clienteDto = new ClienteDto
                {
                    Nombre = rowData[0],
                    Grupo = rowData[1],
                };
                clienteList.Add(clienteDto);
            }
            _dto.Clientes = clienteList;
        }
        public void ToMesaDto (string pathCSV)
        {
            string[] mesas  = File.ReadAllLines(Path.Combine(_projectDirectory, pathCSV));
            List<MesaDto> mesaList = new List<MesaDto>();

            for (int i = 1; i < mesas.Length; i++)
            {
                string[] rowData = mesas[i].Split(',');
                MesaDto mesaDto = new MesaDto
                {
                    Codigo = rowData[0],
                    MinPersonas = Convert.ToInt32(rowData[1]),
                    MaxPersonas = Convert.ToInt32(rowData[2]),
                };
                mesaList.Add(mesaDto);
            }
            _dto.Mesas = mesaList;
        }

        public RestaurantDto GetDtos()
        {
            return _dto;
        }
    }
}
