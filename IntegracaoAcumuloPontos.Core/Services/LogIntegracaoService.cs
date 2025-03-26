using AutoMapper;
using IntegracaoAcumuloPontos.Application.Interfaces;
using IntegracaoAcumuloPontos.Domain.Entities;
using IntegracaoAcumuloPontos.Infrastructure.Context;
using IntegracaoAcumuloPontos.Infrastructure.Interfaces;

namespace IntegracaoAcumuloPontos.Application.Services
{
    public class LogIntegracaoService : BaseService, ILogIntegracaoService
    {

        private readonly ILogIntegracaoRepository _logIntegracaoRepository;
        public LogIntegracaoService(ILogIntegracaoRepository logIntegracaoRepository, IMapper mapper, DataContext db)
         : base(db, mapper)
        {
            _logIntegracaoRepository = logIntegracaoRepository;
        }
        public async Task Criar(string mensagem, string detalhes, dynamic payload)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                var log = new LogIntegracao(mensagem, detalhes, payload);
                await _logIntegracaoRepository.Inserir(log);

                await transaction.CommitAsync();
            }
        }
    }
}
