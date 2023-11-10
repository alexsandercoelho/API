using Domain.Core;
using Domain.Notifications;
using Entities.Entidades;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;
using Services.ViewModels;
using System.Net.Mime;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/")]
    [ApiController]
    public class PerfisController : ApiController
    {
        private readonly IPerfilService _perfilService;

        public PerfisController(IPerfilService perfilService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _perfilService = perfilService;
        }
        
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _perfilService.GetAllAsync();

            return Ok(new SelfResponse
            {
                Href = $"api/perfis",
                Rel = new[] { "collection" },
                Value = response
            });
        }

        [HttpGet("funcionalidades")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetFuncionalidades()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _perfilService.GetAllAsync();

            return Ok(new SelfResponse
            {
                Href = $"api/perfis/funcionalidades",
                Rel = new[] { "collection" },
                Value = response
            });
        }

        [HttpGet("perfis/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _perfilService.GetByIdAsync(id);

            return Ok(new SelfResponse
            {
                Href = $"api/perfis/{id}",
                Rel = new[] { "collection" },
                Value = response
            });
        }

        [HttpPost("perfis")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post([FromBody] PerfilViewModel record)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(record);
                }

                await _perfilService.RegisterAsync(record);

                return Ok(new SelfResponse
                {
                    Href = $"api/pessoas/novo",
                    Rel = new[] { "single" },
                    Value = record
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("perfis/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DeleteSistema(int id)
        {
            try
            {
                var record = await _perfilService.GetByIdAsync(id);

                if (record == null)
                    return BadRequest("Perfil não existe");

                await _perfilService.RemoveAsync(record.Id);

                return Ok(new SelfResponse
                {
                    Href = $"api/perfis/{id}",
                    Rel = new[] { "collection" },
                    Value = "Perfil deletado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
