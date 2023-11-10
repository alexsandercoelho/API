using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("Versao")]
    public  class Versao
    {
        public string? ID { get; set; }
        public string? Nome { get; set; }
        public string? VersaoCor { get; set; }

        public string? VersaoMin { get; set; }

        public string? VersaoMinCont { get; set; }
        
        public DateTime DataCadastro { get; set; }

        //[ForeignKey("Perfil")]
        //[Column(Order = 1)]
       // public int IdPerfil { get; set; }
        //public virtual Categoria Categoria { get; set; }
    }
}
