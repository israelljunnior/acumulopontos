using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Domain.Entities
{
    [Table("Pontos")]
    public class Pontos
    {
        public Pontos() { }
        public Pontos(int pontosObtidos, int idPessoa) 
        {
            IdPessoa = idPessoa;
            DataAtualizacao = DateTime.Now;
            SaldoDePontos = pontosObtidos;
        }

        [Key]
        [Column("id_cartela_pontos")]
        public int IdCartelaPontos { get; set; }
        [Column("id_pessoa")]
        public int IdPessoa { get; set; }
        [Column("saldo_de_pontos")]
        public int SaldoDePontos { get; set; }
        [Column("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }
    }
}
