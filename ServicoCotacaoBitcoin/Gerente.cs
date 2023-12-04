using ServicoCotacaoBitcoin.Tasks;
using ServicoCotacaoBitcoin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicoCotacaoBitcoin
{
    public class Gerente
    {
        private readonly Timer mTimerParam;

        public Gerente()
        {
            mTimerParam = new Timer(new TimerCallback(ObtemParam), null, Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// Processamento principal do gerente. 
        /// </summary>
        public void Processar()
        {
            try
            {
                LogUtil.WriteToFile("Inicio do processamento do gerente");

                ObtemParam();

                //Inicializa as tasks.
                foreach (var task in TaskConfig.TASKS)
                {
                    task.TaskStartBase();
                }

                LogUtil.WriteToFile("Fim do processamento do gerente");
            }
            catch (Exception ex)
            {
                var msg = string.Format("Gerente {0} - Falha no gerente, serviço neste servidor deve ser analisado. {1}", ParamUtil.NomeServico, ex.Message);
                LogUtil.WriteToFile(msg);
            }
        }

        private void ObtemParam(object state = null)
        {
            try
            {
                //Para a contagem do timer.
                mTimerParam.Change(Timeout.Infinite, Timeout.Infinite);

                //Consulta algo no Banco de Dados

            }
            catch (Exception ex)
            {
                LogUtil.WriteToFile($"Erro de processamento ocorrido em {DateTime.Now.ToString("dd-MM-yyyy 'às' HH:mm:ss")} - {ex.Message}");
            }
            finally
            {
                mTimerParam.Change(30000, 30000);
            }
        }
    }
}
