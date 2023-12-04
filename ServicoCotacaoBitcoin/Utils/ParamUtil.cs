using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoCotacaoBitcoin.Utils
{
    public class ParamUtil
    {
        static ParamUtil()
        {
            if (System.Reflection.Assembly.GetEntryAssembly() != null)
                NomeServico = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            else
                NomeServico = "Indeterminado";
        }

        /// <summary>
        /// Nome do executável que está em execução (Nome do serviço windows).
        /// </summary>
        public static readonly string NomeServico;
    }
}
