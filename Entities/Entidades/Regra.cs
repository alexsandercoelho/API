using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("Regra")]
    public  class Regra
    {
        public string? ID { get; set; }
        public string? NomePacote { get; set; }
        public string? VersaoPacote { get; set; }
        public string? GrupoDistrib { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
