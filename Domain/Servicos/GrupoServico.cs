using Domain.Interfaces;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class GrupoServico : IGrupo
    {

        private readonly IGrupo _interfaceGrupo;
        public GrupoServico(IGrupo interfaceGrupo)
        {
            _interfaceGrupo = interfaceGrupo;
        }

        public async Task AdicionarGrupos(Grupo grupo)
        {
            var valido = grupo.ValidarPropriedadeString(grupo.Nome, "Nome");
            if (valido)
                await _interfaceGrupo.AdicionarGrupo(grupo);
        }

        public async Task AlterarGrupo(Grupo grupo)
        {
            var valido = grupo.ValidarPropriedadeString(grupo.Nome, "Nome");
            if (valido)
                await _interfaceGrupo.AlterarGrupo(grupo);
        }
    }
}
