using IntegracaoAcumuloPontos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Infrastructure.Context
{
    public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Consumo> Consumo { get; set; }
        public DbSet<Pontos> Pontos { get; set; }
        public DbSet<Memorial> Memorial { get; set; }
        public DbSet<LogIntegracao> LogIntegracao { get; set; }
    }
}
