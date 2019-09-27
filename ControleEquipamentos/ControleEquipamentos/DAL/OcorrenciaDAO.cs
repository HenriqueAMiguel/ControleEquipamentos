﻿using ControleEquipamentos.Models;
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

        public static List<Ocorrencia> ListarOcorrencias() => ctx.Ocorrencias.ToList();
    }
}
