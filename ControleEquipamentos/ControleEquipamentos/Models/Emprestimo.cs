using ControleEquipamentos.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.Models
{
    class Emprestimo
    {
        public DateTime DataDevolucao { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public StatusEmprestimo StatusEmprestimo { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public string Operador { get; set; }
        public string Usuario { get; set; }
        public List<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();

    }
}
