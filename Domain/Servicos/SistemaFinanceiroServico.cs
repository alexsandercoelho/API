using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistema;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public  class SistemaServico : ISistemaServico
    {
        private readonly InterfaceSistema _interfaceSistema;

        public SistemaServico(InterfaceSistema interfaceSistema)
        {
            _interfaceSistema = interfaceSistema;
        }

        public async Task Salvar(Sistema sistema)
        {
            var valido = sistema.ValidarPropriedadeString(sistema.Nome, "Nome");

            if(valido)
            {
                if (sistema.Id != 0 || string.IsNullOrWhiteSpace(sistema.Id.ToString()))
                    await _interfaceSistema.Update(sistema);
                else
                    await _interfaceSistema.Add(sistema);
            }
        }
    }
}
