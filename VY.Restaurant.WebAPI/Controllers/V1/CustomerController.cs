using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Services;
using VY.Restaurant.Data.Contracts.Data.Repositories;
using VY.Restaurant.Dtos;

namespace VY.Restaurant.WebAPI.Controllers.V1
{
    [Route("/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IRestaurantBuilder _builder;
        private readonly IClienteRepository _clienteRepository;
        public CustomerController( IRestaurantBuilder builder, IClienteRepository clienteRepository)
        {
            _builder = builder;
            _clienteRepository = clienteRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _clienteRepository.Find();
            if(clientes != null)
            {
                return Ok(clientes);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);
            if(cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto value)
        {
            if(value != null) 
            {
                var restDto = new RestaurantDto();
                restDto.SetCliente(value);
                var restDom = _builder.Build(restDto);
                var clientEntities = _clienteRepository.ToEntity(restDom);
                _clienteRepository.Add(clientEntities);
                await _clienteRepository.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);
            if(cliente != null)
            {
                _clienteRepository.Remove(cliente);
                await _clienteRepository.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult>Put([FromBody] ClienteDto body , Guid id)
        {
            var cliente = _clienteRepository.GetById(id);
            if(body.Nombre != null)
            {
                cliente.Nombre = body.Nombre;
                await _clienteRepository.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
