using AutoMapper;
using IntegracaoAcumuloPontos.Application.Interfaces;
using IntegracaoAcumuloPontos.Domain.Entities;
using IntegracaoAcumuloPontos.Infractruture.Interfaces;
using IntegracaoAcumuloPontos.Infrastructure.Context;
using IntegracaoAcumuloPontos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Application.Services
{
    public class PontosService : BaseService, IPontosService
    {
        private readonly IPontosRepository _pontosRepository;

        public PontosService(IConsumoRepository consumoRepository, IMemorialService memorialService, IPontosRepository pontosRepository, IMapper mapper, DataContext db)
         : base(db, mapper)
        {
            _pontosRepository = pontosRepository;
        }
        public async Task<int?> ObterPontuacaoAtual(int idPessoa)
        {

            return (await Obter(idPessoa))?.SaldoDePontos;
        }
        public async Task ComputarPontos(int pontosObtidos, int idPessoa)
        {
            var saldo = await Obter(idPessoa);
            if (saldo != null)
            {
                saldo.DataAtualizacao = DateTime.Now;
                saldo.SaldoDePontos += pontosObtidos;
                await _db.SaveChangesAsync();
            }
            else
            {
                saldo = new Pontos(pontosObtidos, idPessoa);
                await _pontosRepository.Inserir(saldo);
            }
        }
        public async Task<Pontos> Obter(int idPessoa)
        {
            return await _pontosRepository.ObterPorIdPessoa(idPessoa);
        }
    }
}
