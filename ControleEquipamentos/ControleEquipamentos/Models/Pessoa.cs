using ControleEquipamentos.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.Models
{
    [Table("Pessoas")]
    class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? Nascimento { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        //public TipoPessoa Tipo { get; set; }
        public string Usuario { get; set; }
        public string Cpf { get; set; }
        public bool Admin { get; set; }
        public object RG { get; set; }
    }
}
