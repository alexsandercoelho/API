using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistema;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class UsuarioSistemaServico : IUsuarioSistemaServico
    {

        private readonly InterfaceUsuarioSistema _interfaceUsuarioSistema;

        public UsuarioSistemaServico(InterfaceUsuarioSistema interfaceUsuarioSistema)
        {
            _interfaceUsuarioSistema = interfaceUsuarioSistema;
        }

        public async Task CadastrarUsuarioNoSistema(UsuarioSistema usuarioSistema)
        {
            await _interfaceUsuarioSistema.Add(usuarioSistema);
        }


    }
}
