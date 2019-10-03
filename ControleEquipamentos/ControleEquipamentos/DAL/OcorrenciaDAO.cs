using ControleEquipamentos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static Ocorrencia BuscarOcorrencia(int id) => ctx.Ocorrencias.Find(id);

        public static bool AtualizarOcorrencia(Ocorrencia o)
        {
            ctx.Entry(o).State = EntityState.Modified;
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
        public static List<Ocorrencia> ListarOcorrencias() => ctx.Ocorrencias.Include("Equipamento").ToList();
    }
}
