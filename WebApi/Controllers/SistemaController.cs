using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistema;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SistemaController : ControllerBase
    {
        private readonly InterfaceSistema _InterfaceSistema;
        private readonly ISistemaServico _ISistemaServico;
        public SistemaController(InterfaceSistema InterfaceSistema,
            ISistemaServico ISistemaServico)
        {
            _InterfaceSistema = InterfaceSistema;
            _ISistemaServico = ISistemaServico;
        }

        [HttpGet("/api/ListaSistemasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(string emailUsuario)
        {
            return await _InterfaceSistema.ListaSistemasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarSistema")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistema(Sistema sistema)
        {
            await _ISistemaServico.AdicionarSistema(sistema);

            return sistema;
        }

        [HttpPut("/api/AtualizarSistema")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistema(Sistema sistema)
        {
            await _ISistemaServico.AtualizarSistema(sistema);

            return Task.FromResult(sistema);
        }


        [HttpGet("/api/ObterSistema")]
        [Produces("application/json")]
        public async Task<object> ObterSistema(int id)
        {
            return await _InterfaceSistema.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteSistema")]
        [Produces("application/json")]
        public async Task<object> DeleteSistema(int id)
        {
            try
            {
                var sistema = await _InterfaceSistema.GetEntityById(id);

                await _InterfaceSistema.Delete(sistema);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}
