using IntegracaoAcumuloPontos.Application.Interfaces;
using IntegracaoAcumuloPontos.Application.Services;
using IntegracaoAcumuloPontos.Infractruture.Interfaces;
using IntegracaoAcumuloPontos.Infractruture.Repositories;
using IntegracaoAcumuloPontos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using IntegracaoAcumuloPontos.Infrastructure.Interfaces;
using IntegracaoAcumuloPontos.Infrastruture.Repositories;
using AutoMapper;
using Ortobom.OSM.Repository.MapperConfig;
using IntegracaoAcumuloPontos.Infrastructure.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddDependecies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPontosService, PontosService>();
        services.AddScoped<IMemorialService, MemorialService>();
        services.AddScoped<IConsumoService, ConsumoService>();
        services.AddScoped<ILogIntegracaoService, LogIntegracaoService>();

        services.AddScoped<IPontosRepository, PontosRepository>();
        services.AddScoped<IMemorialRepository, MemorialRepository>();
        services.AddScoped<IConsumoRepository, ConsumoRepository>();
        services.AddScoped<ILogIntegracaoRepository, LogIntegracaoRepository>();

        return services;
    }
}