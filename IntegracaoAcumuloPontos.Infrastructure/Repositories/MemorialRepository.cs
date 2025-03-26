using IntegracaoAcumuloPontos.Domain.Entities;
using IntegracaoAcumuloPontos.Infrastructure.Context;
using IntegracaoAcumuloPontos.Infrastructure.Interfaces;
using IntegracaoAcumuloPontos.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Infrastruture.Repositories
{
    public class MemorialRepository : Repository<Memorial>, IMemorialRepository
    {
        public MemorialRepository(DataContext context) : base(context)
        {
        }
    }
}
