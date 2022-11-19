using WebStore.DAL.DatabaseContext;
namespace WebStore.Tests.UnitTests
{
    public abstract class BaseUnitTests
    {
        protected readonly WSDbContext DbContext;
        public BaseUnitTests(WSDbContext dbContext)
        {
            DbContext = dbContext; ;
        }
    }
}