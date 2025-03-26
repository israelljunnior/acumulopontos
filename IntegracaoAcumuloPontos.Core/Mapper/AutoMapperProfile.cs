
using System;
using AutoMapper;
using System.Text;
using IntegracaoAcumuloPontos.Domain.Entities;
using IntegracaoAcumuloPontos.Application.DTOs;

namespace Ortobom.OSM.Repository.MapperConfig
{
    public sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pontos, PontosDto>().ReverseMap();
            CreateMap<Consumo, ConsumoDto>().ReverseMap();
            CreateMap<Memorial, MemorialDto>().ReverseMap();
        }
            
    }
}