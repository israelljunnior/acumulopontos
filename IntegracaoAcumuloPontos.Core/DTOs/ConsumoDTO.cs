using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Application.DTOs
{
    public class ConsumoDto
    {

        [JsonPropertyName("id_consumo")]
        public int IdConsumo { get; set; }

        [JsonPropertyName("id_pessoa")]
        public int IdPessoa { get; set; }

        [JsonPropertyName("data_consumo")]
        public DateTime DataConsumo { get; set; }

        [JsonPropertyName("valor_total")]
        public decimal ValorTotal { get; set; }
    }
}
