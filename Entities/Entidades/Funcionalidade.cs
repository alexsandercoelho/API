using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("Funcionalidade")]
    public  class Funcionalidade
    {

        public int Nome { get; set; }
        
        public EnumTipoDespesa TipoDespesa { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        [ForeignKey("Perfil")]
        [Column(Order = 1)]
        public int IdPerfil { get; set; }
        //public virtual Categoria Categoria { get; set; }
    }
}
