using WebStore.DAL.DatabaseContext;

namespace WebStore.Tests.UnitTests;
public abstract class BaseUnitTests
{
    private readonly WSDbContext DbContext;
    protected BaseUnitTests(WSDbContext dbContext)
    {
        DbContext = dbContext;
    }
}
