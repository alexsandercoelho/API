using Domain.Interfaces;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class PerfilServico : IPerfil
    {

        private readonly IPerfil _interfacePerfil;
        public PerfilServico(IPerfil interfacePerfil)
        {
            _interfacePerfil = interfacePerfil;
        }

        public async Task AdicionarPerfil(Perfil perfil)
        {
            var valido = perfil.ValidarPropriedadeString(perfil.Nome, "Nome");
            if (valido)
                await _interfacePerfil.Add(perfil);
        }

        public async Task AtualizarPerfil(Perfil perfil)
        {
            var valido = perfil.ValidarPropriedadeString(perfil.Nome, "Nome");
            if (valido)
                await _interfacePerfil.Update(perfil);
        }
    }
}
