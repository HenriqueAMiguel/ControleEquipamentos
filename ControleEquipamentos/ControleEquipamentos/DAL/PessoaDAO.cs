using ControleEquipamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.DAL
{
    class PessoaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarPessoa(Pessoa p)
        {
            ctx.Pessoas.Add(p);
            var retorno = ctx.SaveChanges();

            if(retorno > 0)
            {
                return true;
            }

            return false;
        }

        public static Pessoa ObterPessoa(int id)
        {
            return ctx.Pessoas.Find(id);
        }

        public static List<Pessoa> ListarPessoas() => ctx.Pessoas.ToList();

        public static List<Pessoa> ListarOperadores() => ctx.Pessoas.Where(p => p.Admin == true).ToList();

        //TODO: Metodo para Listar apenas usuarios

        public static List<Pessoa> ListarUltimosCadastros(int quantidade)
        {
            return ctx.Pessoas.OrderByDescending(p => p.CriadoEm).Take(10).ToList();
        }
    }
}
