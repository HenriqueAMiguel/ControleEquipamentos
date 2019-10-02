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

        /// <summary>
        /// Cadastra um novo emprestimo
        /// </summary>
        /// <param name="emp">Objeto Emprestimo</param>
        /// <returns></returns>
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

        /// <summary>
        /// Atualiza um emprestimo.
        /// </summary>
        /// <param name="e">Objeto emprestimo com as alterações</param>
        /// <returns></returns>
        public static bool Atualizar(Emprestimo e)
        {
            ctx.Entry(e).State = System.Data.Entity.EntityState.Modified;
            var retorno = ctx.SaveChanges();
            if (retorno > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Busca emprestimo com base no id fornecido
        /// </summary>
        /// <param name="id">id do emprestimo</param>
        /// <returns>Emprestimo específico</returns>
        public static Emprestimo BuscarEmprestimo(int id) => ctx.Emprestimos.Find(id);

        #region Listas
        /// <summary>
        /// Lista todos os emprestimos cadastrados no banco.
        /// </summary>
        /// <returns></returns>
        public static List<Emprestimo> ListarEmprestimos() => ctx.Emprestimos.ToList();

        /// <summary>
        /// Lista apenas os emprestimos com entrega atrasada
        /// </summary>
        /// <returns></returns>
        public static List<Emprestimo> ListarEmprestimosAtrasados() => ctx.Emprestimos.Where(x => x.DataPrevistaDevolucao < DateTime.Now).ToList();

        /// <summary>
        /// Lista os emprestimos conforme parametros escolhidos pelo operador
        /// </summary>
        /// <param name="idUsuario">Usuario que esta cadastrado o emprestimo</param>
        /// <param name="idOperador">Operador que fez os emprestimos</param>
        /// <param name="dataInicio">Data de criação - a partir de</param>
        /// <param name="dataFim">Data de criação - até</param>
        /// <param name="dataPrevistaDevolucaoInicio">Data Previsão da devolução - a partir de</param>
        /// <param name="dataPrevistaDevolucaoFim">Data Previsão da devolução - até</param>
        /// <param name="idEquipamento">Equipamento</param>
        /// <returns>Lista conforme parametros para exibir</returns>
        public static List<Emprestimo> ListarComParametros(int? idUsuario, int? idOperador, DateTime? dataInicio, DateTime? dataFim,
            DateTime? dataPrevistaDevolucaoInicio, DateTime? dataPrevistaDevolucaoFim, int? idEquipamento, bool atrasadosApenas, bool excluiFinalizados)
        {
            if (dataFim == null)
            {
                dataFim = DateTime.Now;
            }

            List<Emprestimo> lista = ctx.Emprestimos.Include("Equipamentos").Include("Usuario").Include("Operador").Where(c => c.DataEmprestimo <= dataFim).ToList();

            if (atrasadosApenas)
                lista = lista.Where(a => a.DataPrevistaDevolucao < DateTime.Now).ToList();

            if (excluiFinalizados)
                lista = lista.Where(f => !f.StatusDoEmprestimo).ToList();

            if (dataInicio != null)
                lista = lista.Where(c => c.DataEmprestimo >= dataInicio).ToList();

            if (dataPrevistaDevolucaoInicio != null)
                lista = lista.Where(c => c.DataPrevistaDevolucao >= dataPrevistaDevolucaoInicio).ToList();

            if (dataPrevistaDevolucaoFim != null)
                lista = lista.Where(c => c.DataPrevistaDevolucao <= dataPrevistaDevolucaoFim).ToList();

            if (idEquipamento != null)
            {
                Equipamento equipamento = ctx.Equipamentos.Find(idEquipamento);
                lista = lista.FindAll(c => c.Equipamentos.Contains(equipamento)).ToList();
            }

            if (idUsuario != null)
            {
                Pessoa pessoaUsuario = ctx.Pessoas.Find(idUsuario);
                lista = lista.Where(c => c.Usuario == pessoaUsuario).ToList();
            }

            if (idOperador != null)
            {
                Pessoa pessoaOperador = ctx.Pessoas.Find(idOperador);
                lista = lista.Where(c => c.Operador == pessoaOperador).ToList();
            }

            return lista;
        }

        /// <summary>
        /// Lista emprestimos carregando equipamentos e que não esteja finalizado
        /// </summary>
        /// <returns>Lista de emprestimo</returns>
        public static List<Emprestimo> ListarEmprestimosComEquipamento() => ctx.Emprestimos.Include("Equipamentos")
                                        .Include("Usuario").Include("Operador")
                                       .Where(x => !x.StatusDoEmprestimo).ToList();
        #endregion

    }
}
