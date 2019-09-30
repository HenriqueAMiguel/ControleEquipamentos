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

        public static void CadastrarPessoa(Pessoa p)
        {
            ctx.Pessoas.Add(p);
            ctx.SaveChanges();
        }

        public static List<Pessoa> ListarPessoas() => ctx.Pessoas.ToList();

        public static List<Pessoa> ListarUltimosCadastros(int quantidade)
        {
            return ctx.Pessoas.OrderByDescending(p => p.CriadoEm).Take(10).ToList();
        }
    }
}
