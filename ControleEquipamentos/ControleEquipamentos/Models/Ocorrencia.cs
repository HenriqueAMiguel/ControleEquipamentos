using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.Models
{
    [Table("Ocorrencias")]
    class Ocorrencia
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public Equipamento Equipamento { get; set; }
        public int Registro { get; set; }
        public DateTime PrevisaoRetorno { get; set; }
    }
}
