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

        public static bool CadastrarEmprestimo(Emprestimo emp)
        {
            ctx.Emprestimos.Add(emp);
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

        public static List<Emprestimo> ListarEmprestimos() => ctx.Emprestimos.ToList();

        public static List<Emprestimo> ListarEmprestimosAtrasados() => ctx.Emprestimos.Where(x => x.DataPrevistaDevolucao < DateTime.Now).ToList();
        public static List<Emprestimo> ListarComParametros(int? idUsuario, int? idOperador, DateTime? dataInicio, DateTime? dataFim,
            DateTime? dataPrevistaDevolucaoInicio, DateTime? dataPrevistaDevolucaoFim,int? idEquipamento)
        {
            if (dataFim == null)
            {
                dataFim = DateTime.Now;
            }                

            List<Emprestimo> lista = ctx.Emprestimos.Include("Equipamentos").Where(c => c.DataEmprestimo <= dataFim).ToList();

            if (dataInicio != null)
                lista = lista.Where(c => c.DataEmprestimo >= dataInicio).ToList();

            if (dataPrevistaDevolucaoInicio != null)
                lista = lista.Where(c => c.DataPrevistaDevolucao >= dataPrevistaDevolucaoInicio).ToList();

            if (dataPrevistaDevolucaoFim != null)
                lista = lista.Where(c => c.DataPrevistaDevolucao >= dataPrevistaDevolucaoFim).ToList();

            if(idEquipamento != null)
            {
                Equipamento equipamento = ctx.Equipamentos.Find(idEquipamento);
                lista = lista.Where(c => c.Equipamentos.Contains(equipamento)).ToList();
            }

            if (idUsuario != null)
            {
                Pessoa pessoa = ctx.Pessoas.Find(idUsuario);
                lista = lista.Where(c => c.Usuario == pessoa).ToList();
            }

            if (idOperador != null)
            {
                Pessoa pessoa = ctx.Pessoas.Find(idOperador);
                lista = lista.Where(c => c.Operador == pessoa).ToList();
            }

            return lista;
        }

        public static List<Emprestimo> ListarEmprestimosComEquipamento() => ctx.Emprestimos.Include("Equipamentos")
                                       .Where(x => !x.StatusDoEmprestimo).ToList();

        public static Emprestimo BuscarEmprestimo(int id) => ctx.Emprestimos.Find(id);

        public static bool Atualizar(Emprestimo e)
        {
            ctx.Entry(e).State = System.Data.Entity.EntityState.Modified;
            var retorno = ctx.SaveChanges();
            if(retorno > 0)
            {
                return true;
            }
            return false;
        }
    }
}
