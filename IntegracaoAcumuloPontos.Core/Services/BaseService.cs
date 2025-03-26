using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoAcumuloPontos.Application.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class BaseService
    {
        protected readonly DbContext _db;
        protected readonly IMapper _mapper;

        public BaseService(DbContext db, IMapper mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
