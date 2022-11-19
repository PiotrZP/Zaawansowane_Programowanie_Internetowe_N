using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DatabaseContext;

namespace WebStore.Services.ConcreteServices
{
    public abstract class BaseService
    {
        protected readonly WSDbContext DbContext; 
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        public BaseService(WSDbContext dbContext,
        IMapper mapper, ILogger logger)
        {
            DbContext = dbContext;
            Logger = logger;
            Mapper = mapper;
        }
    }

}