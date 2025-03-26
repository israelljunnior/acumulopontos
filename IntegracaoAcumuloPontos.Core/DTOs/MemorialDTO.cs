using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Application.DTOs
{
    public class MemorialDto
    {
        [JsonPropertyName("id_registro_memorial")]
        public int IdRegistroMemorial { get; set; }

        [JsonPropertyName("id_consumo")]
        public int IdConsumo { get; set; }

        [JsonPropertyName("valor_total")]
        public decimal ValorTotal { get; set; }

        [JsonPropertyName("valor_pontuavel")]
        public decimal ValorPontuavel { get; set; }

        [JsonPropertyName("pontos_obtidos_na_transacao")]
        public int PontosObtidosNaTransacao { get; set; }

        [JsonPropertyName("data_criacao_registro_memorial")]
        public DateTime DataCriacaoRegistroMemorial { get; set; }
    }
}
