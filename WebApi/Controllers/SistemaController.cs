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
    [AllowAnonymous]
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

        [HttpGet("listar")]
        [Produces("application/json")]
        public async Task<object> ListaSistemas()
        {
            return await _InterfaceSistema.ListaSistemas();
        }

        [HttpGet("listar/{email}")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasPorUsuario([FromQuery]string email)
        {
            return await _InterfaceSistema.ListaSistemasPorUsuario(email);
        }

        [HttpGet("listar/{id}")]
        [Produces("application/json")]
        public async Task<object> ListarSistemasPorId([FromQuery] int id)
        {
            return await _InterfaceSistema.GetEntityById(id);
        }

        [HttpPost("salvar")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistema(Sistema sistema)
        {
            await _ISistemaServico.AdicionarSistema(sistema);

            return sistema;
        }

        [HttpDelete("deletar")]
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
