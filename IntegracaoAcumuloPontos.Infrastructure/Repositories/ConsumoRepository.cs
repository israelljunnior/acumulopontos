using IntegracaoAcumuloPontos.Domain.Entities;
using IntegracaoAcumuloPontos.Infractruture.Interfaces;
using IntegracaoAcumuloPontos.Infrastructure.Context;
using IntegracaoAcumuloPontos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Infractruture.Repositories
{
    public class ConsumoRepository : Repository<Consumo>, IConsumoRepository
    {

        public ConsumoRepository(DataContext context): base(context)
        {
        }
        public async Task AtualizarStatus(Consumo consumo)
        {
            consumo.Processado = true;
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Consumo>> ConsultarConsumosDiaAnterior() 
        {
            return await _dbSet.Where(c => c.DataConsumo.Date == DateTime.Now.AddDays(-1).Date && c.Processado == false).ToListAsync();
        }
    }
}
