using Domain.Interfaces.IPerfil;
using Domain.Interfaces.IRegra;
using Domain.Interfaces.InterfaceServicos;
using Domain.Servicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegrasController : ControllerBase
    {
        private readonly InterfaceRegra _InterfaceRegra;
        private readonly IRegraServico _IRegraServico;
        public RegrasController(Interfacev InterfaceRegra, IRegraServico IRegraServico)
        {
            _InterfaceRegra = InterfaceRegra;
            _IRegraServico = IRegraServico;
        }

        [HttpGet("/api/ListarRegra")]
        [Produces("application/json")]
        public async Task<object> ListarRegra(string emailUsuario)
        {
            return await _InterfaceRegra.ListarRegra(emailUsuario);
        }

        [HttpPost("/api/AdicionarRegra")]
        [Produces("application/json")]
        public async Task<object> AdicionarRegra(Regra regra)
        {
            await _IRegraServico.AdicionarRegra(regra);
            return regra;

        }

        [HttpPut("/api/AtualizarRegra")]
        [Produces("application/json")]
        public async Task<object> AtualizarRegra(Regra regra)
        {
            await _IRegraServico.AtualizarRegra(regra);

            return regra;

        }


        [HttpGet("/api/ObterRegra")]
        [Produces("application/json")]
        public async Task<object> ObterRegra(int id)
        {
            return await _InterfaceRegra.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteRegra")]
        [Produces("application/json")]
        public async Task<object> DeleteRegra(int id)
        {
            try
            {
                var categoria = await _InterfaceRegra.GetEntityById(id);
                await _InterfaceRegra.Delete(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


    }
}
