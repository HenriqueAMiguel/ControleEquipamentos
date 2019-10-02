using ControleEquipamentos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.DAL
{
    class EquipamentoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarEquipamento(Equipamento e)
        {
            ctx.Equipamentos.Add(e);
            var retorno = ctx.SaveChanges();

            if(retorno > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AtualizarEquipamento(Equipamento e)
        {
            ctx.Entry(e).State = EntityState.Modified;
            var retorno = ctx.SaveChanges();

            if (retorno > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void RemoverEquipamento(Equipamento e)
        {
            ctx.Equipamentos.Remove(e);
            ctx.SaveChanges();
        }

        public static List<Equipamento> ListarEquipamento() => ctx.Equipamentos.ToList();

        public static Equipamento  ObterEquipamento(int id)
        {
            return ctx.Equipamentos.Find(id);
        }

        /// <summary>
        /// Retorna true se equipamento estuver em um empréstimo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool ValidarEquipamento(int id)
        {
            var eq = ObterEquipamento(id);
            var emp = EmprestimoDAO.ListarEmprestimosComEquipamento().Where(x => x.Equipamentos.Contains(eq));

            if (emp.Any())
            {
                return true;
            }
            return false;
        }
    }
}
