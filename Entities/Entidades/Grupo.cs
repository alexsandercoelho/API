﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("Grupo")]
    public  class Grupo 
    {
        public string? Nome { get; set; }
        public int QtdPessoas { get; set; }
        public string? VersoesAssociadas { get; set; }

        public string? PropComparacao { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}
