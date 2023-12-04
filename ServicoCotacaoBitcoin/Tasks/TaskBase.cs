using ServicoCotacaoBitcoin.Utils;
using System;
using System.Threading;

namespace ServicoCotacaoBitcoin.Tasks
{
    public class TaskBase
    {
        /// <summary>
        /// Contém o objeto timer da respectiva task.
        /// </summary>
        protected Timer Timer { get; set; }

        /// <summary>
        /// Contém o objeto de configuração da task.
        /// </summary>
        protected virtual TaskConfig TaskConfig { get; }

        /// <summary>
        /// Contém o código do inicio da execução da task.
        /// </summary>
        protected virtual void TaskStart() { }

        /// <summary>
        /// Contém o código de execução da task.
        /// </summary>
        protected virtual void TaskProcess() { }

        /// <summary>
        /// Metodo base de inicio da execução do timer.
        /// </summary>
        public void TaskStartBase()
        {
            try
            {
                //Chama o metodo especifico de inicio da task.
                TaskStart();

                //Paro o timer
                if (Timer != null)
                {
                    Timer.Change(Timeout.Infinite, Timeout.Infinite);
                    Timer = null;
                }

                //Cria o timer e manda iniciar a contagem.
                Timer = new Timer(TaskProcessBase, null, Timeout.Infinite, Timeout.Infinite);
                Timer.Change(1000, 1000);

                LogUtil.WriteToFile($"Inicio da execução de {TaskConfig.TaskName}");
            }
            catch (Exception ex)
            {
                LogUtil.WriteToFile($"{TaskConfig.TaskName} - Falha ao inciar esta Task. Ela deve ser analisada neste servidor. {ex.Message} - Stack : {ex.StackTrace}");
            }
        }

        /// <summary>
        /// Metodo base de execução do timer.
        /// </summary>        
        public void TaskProcessBase(object sender = null)
        {
            try
            {
                //Para a contagem do timer.
                Timer.Change(Timeout.Infinite, Timeout.Infinite);

                TaskProcess();
            }
            catch (Exception ex)
            {
                LogUtil.WriteToFile($"{TaskConfig.TaskName} - Erro na execução desta task. {ex.Message} - Stack : {ex.StackTrace}");
            }
            finally
            {
                //Reinicia a contagem do timer.
                Timer.Change(TaskConfig.IntervaloTimerMS, TaskConfig.IntervaloTimerMS);
            }
        }
    }
}
