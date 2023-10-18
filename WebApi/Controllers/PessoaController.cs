using Domain.Interfaces.IPerfil;
using Domain.Interfaces.IPessoa;
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
    public class PessoaController : ControllerBase
    {
        private readonly InterfacePessoa _InterfacePessoa;
        private readonly IPessoaServico _IPessoaServico;
        public PessoaController(InterfacePessoa InterfacePessoa, IPessoaServico IPessoaServico)
        {
            _InterfacePessoa = InterfacePessoa;
            _IPessoaServico = IPessoaServico;
        }

        [HttpGet("/api/ListarPessoas")]
        [Produces("application/json")]
        public async Task<object> ListarPessoa(string pessoa)
        {
            return await _InterfacePessoa.ListarPessoa(pessoa);
        }

        [HttpPost("/api/AdicionarPessoa")]
        [Produces("application/json")]
        public async Task<object> AdicionarPessoa(Pessoa pessoa)
        {
            await _IPessoaServico.AdicionarPessoa(pessoa);

            return pessoa;

        }

        [HttpPut("/api/AtualizarPessoa")]
        [Produces("application/json")]
        public async Task<object> AtualizarPessoa(Pessoa pessoa)
        {
            await _IPessoaServico.AtualizarPessoa(pessoa);

            return pessoa;

        }
        [HttpGet("/api/ObterPessoa")]
        [Produces("application/json")]
        public async Task<object> ObterPessoa(int id)
        {
            return await _InterfacePessoa.GetEntityById(id);
        }


        [HttpDelete("/api/DeletePessoa")]
        [Produces("application/json")]
        public async Task<object> DeletePessoa(int id)
        {
            try
            {
                var pessoa = await _InterfacePessoa.GetEntityById(id);
                await _InterfacePessoa.Delete(pessoa);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


    }
}
