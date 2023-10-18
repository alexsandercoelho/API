using Domain.Interfaces.IPerfil;
using Domain.Servicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VersaoController : ControllerBase
    {
        private readonly IVersao _InterfaceVersao;
        private readonly IVersaoServico _IVersaoServico;
        public VersaoController(IVersao InterfaceVersao, IVersaoServico IVersaoServico)
        {
            _InterfaceVersao = InterfaceVersao;
            _IVersaoServico = IVersaoServico;
        }

        [HttpGet("/api/ListarVersao")]
        [Produces("application/json")]
        public async Task<object> ListarVersao(string emailUsuario)
        {
            return await _InterfaceVersao.ListarVersao(emailUsuario);
        }

        [HttpPost("/api/AdicionarVersao")]
        [Produces("application/json")]
        public async Task<object> AdicionarVersao(Versao versao)
        {
            await _IVersaoServico.AdicionarVersao(versao);
            return versao;

        }

        [HttpPut("/api/AtualizarVersao")]
        [Produces("application/json")]
        public async Task<object> AtualizarVersao(Versao versao)
        {
            await _IVersaoServico.Atualizarv(versao);
            return versao;

        }

        [HttpGet("/api/ObterVersao")]
        [Produces("application/json")]
        public async Task<object> ObterVersao(int id)
        {
            return await _InterfaceVersao.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteVersao")]
        [Produces("application/json")]
        public async Task<object> DeleteVersao(int id)
        {
            try
            {
                var versao = await _InterfaceVersao.GetEntityById(id);
                await _InterfaceVersao.Delete(versao);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
