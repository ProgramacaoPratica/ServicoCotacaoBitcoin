using ServicoCotacaoBitcoin.Tasks.CotacaoBitcoin;
using System.Collections.Generic;

namespace ServicoCotacaoBitcoin.Tasks
{
    public class TaskConfig
    {
        /// <summary>
        /// Lista de Tasks que devem ser executadas.
        /// </summary>
        public static List<TaskBase> TASKS { get; private set; }

        /// <summary>
        /// Intervalo (em milisegundos) da execução do timer.
        /// </summary>
        public int IntervaloTimerMS { get; set; }

        /// <summary>
        /// Nome amigável da tarefa.
        /// </summary>
        public string TaskName { get; set; }

        static TaskConfig()
        {
            //Aqui deve ser feito o registro das tasks que devem ser executadas.
            TASKS = new List<TaskBase>();
            //Adicionar as tasks na lista
            TASKS.Add(new TaskCotacaoBitcoin());
        }
    }
}
