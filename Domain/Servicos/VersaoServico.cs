using Domain.Interfaces.IPerfil;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Servicos
{
    public class VersaoServico : IVersaoServico
    {

        private readonly IVersao _interfaceVersao;
        public VersaoServico(IVersao interfaceVersao)
        {
            _interfaceVersao = interfaceVersao;
        }

        public async Task AdicionarVersao(Versao versao)
        {
            var valido = versao.ValidarPropriedadeString(versao.Nome, "Nome");
            if (valido)
                await _interfaceVersao.Add(versao);
        }

        public async Task AtualizarVersao(Versao versao)
        {
            var valido = versao.ValidarPropriedadeString(versao.Nome, "Nome");
            if (valido)
                await _interfaceVersao.Update(versao);
        }
    }
}
