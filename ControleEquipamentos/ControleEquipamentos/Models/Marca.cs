using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.Models
{
    [Table("Marcas")]
    class Marca
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }

        public Marca()
        {
            CriadoEm = DateTime.Now;
        }

    }
}
