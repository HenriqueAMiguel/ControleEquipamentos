using ControleEquipamentos.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.Models
{
    class Pessoa
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string Usuario { get; set; }
        public string Cpf { get; set; }
        public bool Admin { get; set; }
    }
}
