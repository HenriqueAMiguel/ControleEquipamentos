using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.Models
{
    class Equipamento
    {
        public string Descricao { get; set; }
        public Marca Marca { get; set; }
        public string Modelo { get; set; }
        public int NumeroRegistro { get; set; }
        public DateTime DataRegistro { get; set; }
        public Pessoa Operador { get; set; }
        public int Contador { get; set; }
        public int Registro { get; set; }
        public bool Inativo { get; set; }
    }
}
