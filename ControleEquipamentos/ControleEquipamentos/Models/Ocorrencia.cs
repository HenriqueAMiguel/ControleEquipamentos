using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.Models
{
    class Ocorrencia
    {
        public string Descricao { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public Equipamento Equipamento { get; set; }
        public int Registro { get; set; }
        public DateTime PrevisaoRetorno { get; set; }
    }
}
