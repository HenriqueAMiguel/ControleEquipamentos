using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.Models
{
    class Context : DbContext
    {
        public Context() : base("DbCtrlEquip") { }

        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
