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

        public async Task AdicionarSistema(Sistema sistema)
        {
             var valido = sistema.ValidarPropriedadeString(sistema.Nome, "Nome");

            if(valido)
            {
                var data = DateTime.Now;

                sistema.DiaFechamento = 1;
                sistema.Ano = data.Year;
                sistema.Mes = data.Month;
                sistema.AnoCopia = data.Year;
                sistema.MesCopia = data.Month;
                sistema.GerarCopiaDespesa = true;

                await _interfaceSistema.Add(sistema);
            }
        }

        public async Task AtualizarSistema(Sistema sistema)
        {
            var valido = sistema.ValidarPropriedadeString(sistema.Nome, "Nome");

            if (valido)
            {
                sistema.DiaFechamento = 1;
                await _interfaceSistema.Update(sistema);
            }
        }
    }
}
