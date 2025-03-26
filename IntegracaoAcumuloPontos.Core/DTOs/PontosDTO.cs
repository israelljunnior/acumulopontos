using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Application.DTOs
{
    public class PontosDto
    {
        [JsonPropertyName("id_cartela_pontos")]
        public int IdCartelaPontos { get; set; }

        [JsonPropertyName("id_pessoa")]
        public int IdPessoa { get; set; }

        [JsonPropertyName("saldo_de_pontos")]
        public int SaldoDePontos { get; set; }

        [JsonPropertyName("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }
    }
}
