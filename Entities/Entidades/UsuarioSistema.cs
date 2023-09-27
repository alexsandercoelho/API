using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("UsuarioSistema")]
    public class UsuarioSistema
    {
        public int Id { get; set; }
        public string EmailUsuario { get; set; }
        public bool Administrador { get; set; }
        public bool SistemaAtual { get; set; }


        [ForeignKey("Sistema")]
        [Column(Order = 1)]
        public int IdSistema { get; set; }
        public virtual Sistema Sistema { get; set; }
    }
}
