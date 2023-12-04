using Newtonsoft.Json;

namespace ServicoCotacaoBitcoin.Tasks.CotacaoBitcoin.DTOs
{
    public class CotacaoDTO
    {
        [JsonProperty("pair")]
        public string Pair { get; set; }

        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("buy")]
        public decimal Buy { get; set; }

        [JsonProperty("sell")]
        public decimal Sell { get; set; }

        [JsonProperty("open")]
        public decimal Open { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }
    }
}
