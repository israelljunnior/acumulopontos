using AutoMapper;
using IntegracaoAcumuloPontos.Application.DTOs;
using IntegracaoAcumuloPontos.Application.Interfaces;
using IntegracaoAcumuloPontos.Domain.Entities;
using IntegracaoAcumuloPontos.Infractruture.Interfaces;
using IntegracaoAcumuloPontos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Application.Services
{
    public class ConsumoService : BaseService, IConsumoService
    {
        private readonly IConsumoRepository _consumoRepository;
        private readonly IMemorialService _memorialService;
        private readonly IPontosService _pontosService;
        private readonly ILogIntegracaoService _logIntegracaoService;

        public ConsumoService(IConsumoRepository consumoRepository, IMemorialService memorialService, IPontosService pontosService,
            ILogIntegracaoService logIntegracaoService, IMapper mapper, DataContext db)
         : base(db, mapper)
        {
            _consumoRepository = consumoRepository;
            _memorialService = memorialService;
            _pontosService = pontosService;
            _logIntegracaoService = logIntegracaoService;
        }
        public async Task<Consumo> Criar(ConsumoDto consumo)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    var entity = await _consumoRepository.Inserir(_mapper.Map<Consumo>(consumo));
                    await transaction.CommitAsync();
                    return entity;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    await _logIntegracaoService.Criar("Erro ocorreu durante criação do consumo",
                        $"Exception: {ex.Message}\\n {ex.Source}\\n {ex.StackTrace}\\n {ex.InnerException}\"", consumo);

                    throw ex;
                }
            }
        }
        public async Task<ICollection<Consumo>> CriarLote(ICollection<ConsumoDto> consumo)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    var list = new HashSet<Consumo>();
                    foreach (var item in consumo)
                    {
                        list.Add(await _consumoRepository.Inserir(_mapper.Map<Consumo>(item)));
                    }

                    await transaction.CommitAsync();

                    return list;

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    await _logIntegracaoService.Criar("Erro ocorreu durante Importação dos consumos",
                        $"Exception: {ex.Message}\\n {ex.Source}\\n {ex.StackTrace}\\n {ex.InnerException}\"", consumo);
                    throw ex;
                }
            }
        }
        public async Task ComputarPontosTempoReal(ConsumoDto consumo)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    var entidade = _mapper.Map<Consumo>(consumo);
                    entidade.Processado = true;
                    await _consumoRepository.Inserir(entidade);
                    var memorial = await _memorialService.Criar(entidade);
                    await _pontosService.ComputarPontos(memorial.PontosObtidosNaTransacao, consumo.IdPessoa);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    await _logIntegracaoService.Criar("Erro ocorreu durante Computação dos Pontos",
                        $"Exception: {ex.Message}\\n {ex.Source}\\n {ex.StackTrace}\\n {ex.InnerException}\"", consumo);

                    throw ex;
                }
            }
        }

        public async Task TransformacaoPosIngestao(ICollection<ConsumoDto> consumos)
        {
            await CriarLote(consumos);

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    
                    var clientes = new Dictionary<int, int>();
                    var consumosDiaAnterior = await _consumoRepository.ConsultarConsumosDiaAnterior();
                    foreach (var consumo in consumosDiaAnterior)
                    {
                        var memorial = await _memorialService.Criar(consumo);
                        if (clientes.ContainsKey(consumo.IdPessoa)) {
                            clientes[consumo.IdPessoa] += memorial.PontosObtidosNaTransacao;
                        } else clientes.Add(consumo.IdPessoa, memorial.PontosObtidosNaTransacao);

                        await _consumoRepository.AtualizarStatus(consumo);
                    }

                    foreach (var item in clientes)
                    {
                        await _pontosService.ComputarPontos(item.Value, item.Key);
                    }

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    await _logIntegracaoService.Criar("Erro ocorreu durante Computação dos Pontos dos consumos importados",
                        $"Exception: {ex.Message}\\n {ex.Source}\\n {ex.StackTrace}\\n {ex.InnerException}\"", consumos);

                    throw ex;
                }
            }
        }
    }
}
