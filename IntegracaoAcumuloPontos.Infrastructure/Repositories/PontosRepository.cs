using IntegracaoAcumuloPontos.Domain.Entities;
using IntegracaoAcumuloPontos.Infrastructure.Context;
using IntegracaoAcumuloPontos.Infrastructure.Interfaces;
using IntegracaoAcumuloPontos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Infractruture.Repositories
{
    public class PontosRepository : Repository<Pontos>, IPontosRepository
    {

        public PontosRepository(DataContext context) : base (context)
        {
        }
        public async Task<Pontos> ObterPorIdPessoa(int idPessoa)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.IdPessoa == idPessoa);
        }
    }
}
