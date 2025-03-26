using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Domain.Entities
{

    [Table("Consumo")]
    public class Consumo
    {
        [Key]
        [Column("id_consumo")]
        public int IdConsumo { get; set; }
        [Column("id_pessoa")]
        public int IdPessoa { get; set; }
        [Column("data_consumo")]
        public DateTime DataConsumo { get; set; }
        [Column("valor_total", TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }
        public bool Processado { get; set; }
        public virtual Memorial Memorial { get; set; }
    }
}
