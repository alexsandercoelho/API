using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class Perfil : Base
    {
        public DateTime DataInclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public virtual IList<Funcionalidade> Funcionalidades { get; set; }
    }
}
