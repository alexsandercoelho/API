using Domain.Interfaces;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class RegraServico : IRegra
    {

        private readonly IRegra _interfaceRegra;
        public RegraServico(IRegra interfaceRegra)
        {
            _interfaceRegra = interfaceRegra;
        }

        public async Task AdicionarRegra(Regra regra)
        {
            var valido = regra.ValidarPropriedadeString(regra.Nome, "Nome");
            if (valido)
                await _interfaceRegra.AdicionarRegra(regra);
        }

        public async Task AtualizarRegra(Regra regra)
        {
            var valido = regra.ValidarPropriedadeString(regra.Nome, "Nome");
            if (valido)
                await _interfaceRegra.AlterarRegra(regra);
        }
    }
}
