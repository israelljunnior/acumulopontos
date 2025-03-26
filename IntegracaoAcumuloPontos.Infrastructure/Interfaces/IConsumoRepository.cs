using IntegracaoAcumuloPontos.Domain.Entities;
using IntegracaoAcumuloPontos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Infractruture.Interfaces
{
    public interface IConsumoRepository : IRepository<Consumo>
    {
        Task AtualizarStatus(Consumo consumo);
        Task<ICollection<Consumo>> ConsultarConsumosDiaAnterior();
    }
}
