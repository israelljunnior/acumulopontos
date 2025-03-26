using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> ObterPorId(int id);
        Task<TEntity> Inserir(TEntity entity);
    }
}
