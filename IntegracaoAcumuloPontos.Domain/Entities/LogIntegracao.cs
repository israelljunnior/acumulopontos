using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace IntegracaoAcumuloPontos.Domain.Entities
{
    [Table("LogIntegracao")]
    public class LogIntegracao
    {
        public LogIntegracao() { }
        public LogIntegracao(string mensagem, string detalhes, dynamic payload)
        {
            DataCriacao = DateTime.Now;
            Mensagem = mensagem;
            Detalhes = detalhes;
            Payload = JsonSerializer.Serialize(payload);
        }

        [Key]
        [Column("id_log")]
        public int IdLog { get; set; }
        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; }
        [Column("mensagem")]
        public string Mensagem { get; set; }
        [Column("detalhes")]
        public string Detalhes { get; set; }
        [Column("payload")]
        public string Payload { get; set; }
    }
}
