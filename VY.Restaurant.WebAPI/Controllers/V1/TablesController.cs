using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using VY.Restaurant.Business.Contracts.Services;
using VY.Restaurant.Data.Contracts.Data.Repositories;
using VY.Restaurant.Dtos;

namespace VY.Restaurant.WebAPI.Controllers.V1
{
    [Route("/[controller]")]
    public class TablesController : Controller
    {
        private readonly IRestaurantBuilder _builder;
        private readonly IMesaRepository _mesaRepository;
        public TablesController(IRestaurantBuilder builder, IMesaRepository mesaRepository)
        {
            _builder = builder;
            _mesaRepository = mesaRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var mesas = _mesaRepository.Find();
            if (mesas != null)
            {
                return Ok(mesas);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var mesa = _mesaRepository.GetById(id);
            if (mesa != null)
            {
                return Ok(mesa);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MesaDto value)
        {
            if (value != null)
            {
                var restDto = new RestaurantDto();
                restDto.SetMesa(value);
                var restDom = _builder.Build(restDto);
                var mesaEntities = _mesaRepository.ToEntity(restDom);
                _mesaRepository.Add(mesaEntities);
                await _mesaRepository.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var mesa = _mesaRepository.GetById(id);
            if (mesa != null)
            {
                _mesaRepository.Remove(mesa);
                await _mesaRepository.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] MesaDto body, Guid id)
        {
            var mesa = _mesaRepository.GetById(id);
            if (body != null)
            {
                mesa.Codigo = body.Codigo != null? body.Codigo : mesa.Codigo;
                mesa.CapacidadMax = body.MaxPersonas != mesa.CapacidadMax ? body.MaxPersonas : mesa.CapacidadMax;
                mesa.CapacidadMin = body.MinPersonas != mesa.CapacidadMin ? body.MinPersonas : mesa.CapacidadMax;
                await _mesaRepository.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
