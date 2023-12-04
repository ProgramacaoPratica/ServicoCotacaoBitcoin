using Newtonsoft.Json;
using RestSharp;
using ServicoCotacaoBitcoin.Tasks.CotacaoBitcoin.DTOs;
using ServicoCotacaoBitcoin.Utils;
using System;
using System.Collections.Generic;

namespace ServicoCotacaoBitcoin.Tasks.CotacaoBitcoin
{
    public class TaskCotacaoBitcoin : TaskBase
    {
        private readonly TaskConfig mTaskConfig;

        public TaskCotacaoBitcoin()
        {
            mTaskConfig = new TaskConfig()
            {
                IntervaloTimerMS = 5000,
                TaskName = nameof(TaskCotacaoBitcoin)
            };
        }

        protected override TaskConfig TaskConfig => mTaskConfig;

        protected override void TaskProcess()
        {
            var cliente = new RestClient("https://api.mercadobitcoin.net/api/v4");
            var request = new RestRequest("tickers", Method.Get);
            request.AddQueryParameter("symbols", "BTC-BRL");
            var response = cliente.Execute(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var cotacoes = JsonConvert.DeserializeObject<List<CotacaoDTO>>(response.Content);
                if(cotacoes.Count > 0)
                    LogUtil.WriteToFile($"Cotação do BitCoin em {DateTime.Now:dd-MM-yyyy 'às' HH:mm:ss} - {cotacoes[0].Last:C}");
                else
                    LogUtil.WriteToFile($"Cotação do BitCoin não encontrada em {DateTime.Now:dd-MM-yyyy 'às' HH:mm:ss}");
            }
            else
            {
                LogUtil.WriteToFile($"Erro ao consultar cotação do Bitcoin em {DateTime.Now:dd-MM-yyyy 'às' HH:mm:ss} - {response.Content}");
            }
        }
    }
}
