using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.Models
{
    [Table("Equipamentos")]
    class Equipamento
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int NumeroRegistro { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public Pessoa Operador { get; set; }
        public int Contador { get; set; } = 0;
        public bool Inativo { get; set; }
    }
}
