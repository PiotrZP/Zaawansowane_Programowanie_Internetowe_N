using WebStore.DAL.Data;
namespace WebStore.Tests.UnitTests
{
    public abstract class BaseUnitTests
    {
        protected readonly ApplicationDbContext DbContext;
        public BaseUnitTests(ApplicationDbContext dbContext)
        {
            DbContext = dbContext; ;
        }
    }
}