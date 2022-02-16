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
    public class GroupsController : Controller
    {
        private readonly IRestaurantBuilder _builder;
        private readonly IGrupoRepository _grupoRepository;
        public GroupsController(IRestaurantBuilder builder, IGrupoRepository grupoRepository)
        {
            _builder = builder;
            _grupoRepository = grupoRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var grupos = _grupoRepository.Find();
            if (grupos != null)
            {
                return Ok(grupos);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var grupo = _grupoRepository.GetById(id);
            if (grupo != null)
            {
                return Ok(grupo);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GrupoDto value)
        {
            if (value != null)
            {
                var restDto = new RestaurantDto();
                restDto.SetGrupo(value);
                var restDom = _builder.Build(restDto);
                var grupoEntities = _grupoRepository.ToEntity(restDom);
                _grupoRepository.Add(grupoEntities);
                await _grupoRepository.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var grupo = _grupoRepository.GetById(id);
            if (grupo != null)
            {
                _grupoRepository.Remove(grupo);
                await _grupoRepository.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] GrupoDto body, Guid id)
        {
            var grupo = _grupoRepository.GetById(id);
            if (body!= null)
            {
                grupo.HoraReserva = body.Hora != null ? body.Hora : grupo.HoraReserva;
                grupo.Codigo = body.Grupo != null ? body.Grupo : grupo.Codigo;
                grupo.NumeroPersonas = body.NumPersonas != 0? body.NumPersonas : grupo.NumeroPersonas;
                await _grupoRepository.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
