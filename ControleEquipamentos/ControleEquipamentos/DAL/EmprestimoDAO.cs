using ControleEquipamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.DAL
{
    class EmprestimoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarEmprestimo(Emprestimo emp)
        {
            ctx.Emprestimos.Add(emp);
            ctx.SaveChanges();
        }

        public static List<Emprestimo> ListarEmprestimos() => ctx.Emprestimos.ToList();

        public static List<Emprestimo> ListarEmprestimosAtrasados() => ctx.Emprestimos.Where(x => x.DataPrevistaDevolucao < DateTime.Now).ToList();
    }
}
