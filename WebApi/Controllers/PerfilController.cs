using Domain.Interfaces.IPerfil;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {

        private readonly InterfacePerfil _InterfacePerfil;
        private readonly IPerfilServico _IPerfilServico;

        public PerfilController(InterfacePerfil InterfacePerfil, IPerfilServico IPerfilServico)
        {
            _InterfacePerfil = InterfacePerfil;
            _IPerfilServico = IPerfilServico;
        }

        [HttpGet("/api/ListarPerfilUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarPerfilUsuario(string emailUsuario)
        {
            return await _InterfacePerfil.ListarPerfilUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarPerfil")]
        [Produces("application/json")]
        public async Task<object> AdicionarPerfil(Perfil perfil)
        {
            await _IPerfilServico.AdicionarPerfil(perfil);

            return perfil;
        }

        [HttpPut("/api/AtualizarPerfil")]
        [Produces("application/json")]
        public async Task<object> AtualizarPerfil(Perfil perfil)
        {
            await _IPerfilServico.AtualizarPerfil(perfil);

            return perfil;
        }

        [HttpGet("/api/ObterPerfil")]
        [Produces("application/json")]
        public async Task<object> ObterPerfil(int id)
        {
            return await _InterfacePerfil.GetEntityById(id);
        }


        [HttpDelete("/api/DeletePerfil")]
        [Produces("application/json")]
        public async Task<object> DeletePerfil(int id)
        {
            try
            {
                var perfil = await _InterfacePerfil.GetEntityById(id);
                await _InterfacePerfil.Delete(perfil);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }



    }
}
