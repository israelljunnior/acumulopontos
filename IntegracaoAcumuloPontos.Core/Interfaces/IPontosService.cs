using IntegracaoAcumuloPontos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Application.Interfaces
{
    public interface IPontosService
    {
        Task<Pontos> Obter(int idPessoa);
        Task<int?> ObterPontuacaoAtual(int idPessoa);
        Task ComputarPontos(int pontosObtidos, int idPessoa);
    }
}
