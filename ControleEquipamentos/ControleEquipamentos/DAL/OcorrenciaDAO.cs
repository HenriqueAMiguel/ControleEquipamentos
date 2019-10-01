using ControleEquipamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEquipamentos.DAL
{
    class OcorrenciaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarOcorrencia(Ocorrencia o)
        {
            ctx.Ocorrencias.Add(o);
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

        //TODO: Quando criar o campo Status da Ocorrencia, fazer metodo para Listar apenas as ocorrencias ativas
        public static List<Ocorrencia> ListarOcorrencias() => ctx.Ocorrencias.ToList();
    }
}
