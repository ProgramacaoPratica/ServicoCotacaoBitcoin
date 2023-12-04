using ServicoCotacaoBitcoin.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicoCotacaoBitcoin
{
    public partial class ADM : ServiceBase
    {
        private readonly Gerente mGerente = new Gerente();
        public ADM()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += OnError;

#if DEBUG
            //Inicialização de desenvolvimento para debugar.
            OnStart(null);
#endif
        }

        protected override void OnStart(string[] args)
        {
            LogUtil.WriteToFile("Serviço iniciado em " + DateTime.Now.ToString("dd-MM-yyyy 'às' HH:mm:ss"));

            var thread = new Thread(new ThreadStart(mGerente.Processar));
            thread.Start();
        }

        protected override void OnStop()
        {
            LogUtil.WriteToFile("Serviço parado em " + DateTime.Now.ToString("dd-MM-yyyy 'às' HH:mm:ss"));
        }

        protected void OnError(object sender, UnhandledExceptionEventArgs args)
        {
            if (args.ExceptionObject.GetType() == typeof(Exception))
            {
                LogUtil.WriteToFile($"Erro ocorrido em {DateTime.Now.ToString("dd-MM-yyyy 'às' HH:mm:ss")} - {((Exception)args.ExceptionObject).Message}");
            }
        }
    }
}
