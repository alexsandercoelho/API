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
    public class GruposController : ControllerBase
    {
        private readonly IGrupo _InterfaceGrupo;
        private readonly IGrupoServico _IGrupoServico;
        public GruposController(IGrupo InterfaceGrupo, IGrupoServico IGrupoServico)
        {
            _InterfaceGrupo = InterfaceGrupo;
            _IGrupoServico = IGrupoServico;
        }

        [HttpGet("/api/ListarGrupos")]
        [Produces("application/json")]
        public async Task<object> ListarGrupos(string emailUsuario)
        {
            return await _InterfaceGrupo.ListarGrupos(emailUsuario);
        }

        [HttpPost("/api/AdicionarGrupo")]
        [Produces("application/json")]
        public async Task<object> AdicionarGrupo(Grupo grupo)
        {
            await _IGrupoServico.AdicionarGrupo(grupo);

            return grupo;

        }

        [HttpPut("/api/AtualizarGrupo")]
        [Produces("application/json")]
        public async Task<object> AtualizarGrupo(Grupo grupo)
        {
            await _IGrupoServico.AtualizarGrupo(grupo);

            return grupo;

        }


        [HttpGet("/api/ObterGrupo")]
        [Produces("application/json")]
        public async Task<object> ObterGrupo(int id)
        {
            return await _InterfaceGrupo.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteGrupo")]
        [Produces("application/json")]
        public async Task<object> DeleteGrupo(int id)
        {
            try
            {
                var categoria = await _InterfaceGrupo.GetEntityById(id);
                await _InterfaceGrupo.Delete(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


    }
}
