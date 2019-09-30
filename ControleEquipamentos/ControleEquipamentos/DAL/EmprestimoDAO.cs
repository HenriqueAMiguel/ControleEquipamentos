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
        public static List<Emprestimo> ListarComParametros(int? idUsuario, int? idOperador, DateTime? dataInicio, DateTime? dataFim,
            DateTime? dataPrevistaDevolucaoInicio, DateTime? dataPrevistaDevolucaoFim,int? idEquipamento)
        {
            if (dataFim == null)
            {
                dataFim = DateTime.Now;
            }                

            List<Emprestimo> lista = ctx.Emprestimos.Include("Equipamento").Where(c => c.DataEmprestimo <= dataFim).ToList();

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
    }
}
