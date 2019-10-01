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
    [Table("Emprestimos")]
    class Emprestimo
    {
        [Key]
        public int Id { get; set; }
        public StatusEmprestimo Status { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public StatusEmprestimo StatusEmprestimo { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public Pessoa Operador { get; set; }
        public Pessoa Usuario { get; set; }
        public List<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();

    }
}
