using AutoMapper;
using IntegracaoAcumuloPontos.Application.Interfaces;
using IntegracaoAcumuloPontos.Domain.Entities;
using IntegracaoAcumuloPontos.Infrastructure.Context;
using IntegracaoAcumuloPontos.Infrastructure.Interfaces;

namespace IntegracaoAcumuloPontos.Application.Services
{
    public class MemorialService : BaseService, IMemorialService
    {
        private readonly IMemorialRepository _memorialRepository;
        private readonly IPontosService _pontosService;
        public MemorialService(IMemorialRepository memorialRepository, IMapper mapper, DataContext db)
         : base(db, mapper)
        {
            _memorialRepository = memorialRepository;
        }
        public async Task<Memorial> Criar(Consumo consumo)
        {
            var memorial = new Memorial(consumo);
            return await _memorialRepository.Inserir(memorial);
        }
    }
}
