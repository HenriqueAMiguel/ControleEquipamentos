using ControleEquipamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.DAL
{
    class EquipamentoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarEquipamento(Equipamento e)
        {
            ctx.Equipamentos.Add(e);
            ctx.SaveChanges();
        }

        public static void RemoverEquipamento(Equipamento e)
        {
            ctx.Equipamentos.Remove(e);
            ctx.SaveChanges();
        }

        public static List<Equipamento> ListarEquipamento() => ctx.Equipamentos.Include("Emprestimo").ToList();
    }
}
