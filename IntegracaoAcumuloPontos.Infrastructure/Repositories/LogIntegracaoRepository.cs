using System.Threading.Tasks;
using IntegracaoAcumuloPontos.Domain.Entities;
using IntegracaoAcumuloPontos.Infractruture.Interfaces;
using IntegracaoAcumuloPontos.Infrastructure.Context;
using IntegracaoAcumuloPontos.Infrastructure.Interfaces;

namespace IntegracaoAcumuloPontos.Infrastructure.Repositories
{
    public class LogIntegracaoRepository : Repository<LogIntegracao>, ILogIntegracaoRepository
    {
        public LogIntegracaoRepository(DataContext context) : base(context)
        {
        }
    }
}
