using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistema;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaController : ControllerBase
    {
        private readonly InterfaceUsuarioSistema _InterfaceUsuarioSistema;
        private readonly IUsuarioSistemaServico _IUsuarioSistemaServico;
        public UsuarioSistemaController(InterfaceUsuarioSistema InterfaceUsuarioSistema,
            IUsuarioSistemaServico IUsuarioSistemaServico)
        {
            _InterfaceUsuarioSistema = InterfaceUsuarioSistema;
            _IUsuarioSistemaServico = IUsuarioSistemaServico;
        }

        [HttpGet("/api/ListarUsuariosSistema")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(int idSistema)
        {
            return await _InterfaceUsuarioSistema.ListarUsuariosSistema(idSistema);
        }


        [HttpPost("/api/CadastrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _IUsuarioSistemaServico.CadastrarUsuarioNoSistema(
                   new UsuarioSistema
                   {
                       IdSistema = idSistema,
                       EmailUsuario = emailUsuario,
                       Administrador = false,
                       SistemaAtual = true
                   });
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }

        [HttpDelete("/api/DeleteUsuarioSistema")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistema(int id)
        {
            try
            {
                var usuarioSistema = await _InterfaceUsuarioSistema.GetEntityById(id);

                await _InterfaceUsuarioSistema.Delete(usuarioSistema);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }
    }
}
