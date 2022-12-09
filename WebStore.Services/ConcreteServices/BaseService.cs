using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DataAccess;
namespace WebStore.Services.ConcreteServices
{
    public abstract class BaseService
    {
        protected readonly ApplicationDbContext DbContext;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        public BaseService(ApplicationDbContext dbContext,
        IMapper mapper, ILogger logger)
        {
            DbContext = dbContext;
            Logger = logger;
            Mapper = mapper;
        }
    }
}
