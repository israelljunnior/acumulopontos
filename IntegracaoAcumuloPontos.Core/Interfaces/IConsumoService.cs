using IntegracaoAcumuloPontos.Application.DTOs;
using IntegracaoAcumuloPontos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Application.Interfaces
{
    public interface IConsumoService
    {
        Task<Consumo> Criar(ConsumoDto consumo);
        Task ComputarPontosTempoReal(ConsumoDto consumo);
        Task TransformacaoPosIngestao(ICollection<ConsumoDto> consumos);
    }
}
