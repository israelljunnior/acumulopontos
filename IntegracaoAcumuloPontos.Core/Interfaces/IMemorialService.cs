using IntegracaoAcumuloPontos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Application.Interfaces
{
    public interface IMemorialService
    {
        Task<Memorial> Criar(Consumo consumo);
    }
}
