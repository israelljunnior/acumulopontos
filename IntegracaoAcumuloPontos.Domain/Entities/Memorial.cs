using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Domain.Entities
{
    [Table("Memorial")]
    public class Memorial
    {

        public Memorial() { }
        public Memorial(Consumo consumo)
        {
            if (consumo == null)
                throw new ArgumentNullException(nameof(consumo));

            IdConsumo = consumo.IdConsumo;
            ValorTotal = consumo.ValorTotal;
            ValorPontuavel = Convert.ToInt32(Math.Floor(consumo.ValorTotal * 0.10m));
            PontosObtidosNaTransacao = ValorPontuavel;
            DataCriacaoRegistroMemorial = DateTime.Now;
            Consumo = consumo;
        }

        [Key]
        [Column("id_registro_memorial")]
        public int IdRegistroMemorial { get; set; }
        [ForeignKey("Consumo")]
        [Column("id_consumo")]
        public int IdConsumo { get; set; }
        [Column("valor_total", TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }
        [Column("valor_pontuavel")]
        public int ValorPontuavel { get; set; }
        [Column("pontos_obtidos_na_transacao")]
        public int PontosObtidosNaTransacao { get; set; }
        [Column("data_criacao_registro_memorial")]
        public DateTime DataCriacaoRegistroMemorial { get; set; }
        public virtual Consumo Consumo { get; set; }
    }

}
