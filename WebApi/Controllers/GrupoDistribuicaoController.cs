using Domain.Core;
using Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ViewModels;
using System.Net.Mime;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/")]
    public class GrupoDistribuicaoController : ApiController
    {
        private readonly IGrupoDistribuicaoService _service;

        public GrupoDistribuicaoController(IGrupoDistribuicaoService service,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _service = service;
        }

        [HttpGet("grupos")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _service.GetAllAsync();

            return Ok(new SelfResponse
            {
                Href = $"api/grupos",
                Rel = new[] { "collection" },
                Value = response
            });
        }

        [HttpPost("grupos")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post([FromBody] GrupoDistribuicaoViewModel record)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(record);
                }

                await _service.RegisterAsync(record);

                return Ok(new SelfResponse
                {
                    Href = $"api/grupos/",
                    Rel = new[] { "single" },
                    Value = record
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("grupos")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Put([FromBody] GrupoDistribuicaoViewModel record)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(record);
                }

                await _service.UpdateAsync(record);

                return Ok(new SelfResponse
                {
                    Href = $"api/grupos",
                    Rel = new[] { "single" },
                    Value = record
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("grupos/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var record = await _service.GetByIdAsync(id);

                if (record == null)
                    return BadRequest("Sistema não existe");

                await _service.RemoveAsync(record.Id);

                return Ok(new SelfResponse
                {
                    Href = $"api/grupos/{id}",
                    Rel = new[] { "collection" },
                    Value = "Grupo de Distribuição deletado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
