using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("Perfil")]
    public class Perfil : Base
    {
        [ForeignKey("Sistema")]
        [Column(Order = 1)]
        public int IdSistema { get; set; }
       // public virtual Sistema Sistema { get; set; }
    }
}
