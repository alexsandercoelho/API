using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISistemaServico
    {
        Task AdicionarSistema(Sistema sistema);
        Task AtualizarSistema(Sistema sistema);
    }
}
