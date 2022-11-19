using Microsoft.EntityFrameworkCore;
using WebStore.DAL.DatabaseContext;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;

namespace WebStore.Tests.UnitTests;
public class StoreServiceUnitTests : BaseUnitTests
{
    private readonly IStoreService _service;
    private readonly WSDbContext _context;
    public StoreServiceUnitTests(WSDbContext dbContext,
        IStoreService storeService) : base(dbContext)
    {
        _service = storeService;
        _context = dbContext;
    }

    [Fact]
    public void GetStationaryStoreTest()
    {
        var stationaryStore = _service.GetStationaryStore(p => p.Name == "Store 3");
        Assert.NotNull(stationaryStore);
    }

    [Fact]
    public void GetMultipleStationaryStoresTest()
    {
        var stationaryStores = _service.GetStationaryStores(p => p.Id >= 1 && p.Id <= 2);
        Assert.NotNull(stationaryStores);
        Assert.NotEmpty(stationaryStores);
        Assert.Equal(2, stationaryStores.Count());
    }

    [Fact]
    public void GetAllStationaryStoresTest()
    {
        var stationaryStores = _service.GetStationaryStores();
        Assert.NotNull(stationaryStores);
        Assert.NotEmpty(stationaryStores);
        Assert.Equal(stationaryStores.Count(), stationaryStores.Count());
    }

    [Fact]
    public void AddNewStationaryStoreTest()
    {
        var newStationaryStoreVm = new AddOrUpdateStationaryStoreVm()
        {
            Name = "New Store",
        };

        var createdStationaryStore = _service.AddOrUpdateStationaryStore(newStationaryStoreVm);
        Assert.NotNull(createdStationaryStore);
        Assert.Equal("New Store", createdStationaryStore.Name);
    }

    [Fact]
    public void UpdateStationaryStoreTest()
    {
        var updateStationaryStoreVm = new AddOrUpdateStationaryStoreVm()
        {
            Id = 1,
            Name = "new name"
        };
        var editedStationaryStoreVm = _service.AddOrUpdateStationaryStore(updateStationaryStoreVm);
        Assert.NotNull(editedStationaryStoreVm);
        Assert.Equal("new name", editedStationaryStoreVm.Name);
    }

    [Fact]
    public async Task DeleteStationaryStoreTest()
    {
        int stationaryStoreId = 3;

        bool doesStationaryStoreExistsBefore = await _context.StationaryStore.AnyAsync(x => x.Id == stationaryStoreId);
        await _service.DeleteStationaryStore(x => x.Id == stationaryStoreId);
        bool doesStationaryStoreExistsAfter = await _context.StationaryStore.AnyAsync(x => x.Id == stationaryStoreId);

        Assert.True(doesStationaryStoreExistsBefore);
        Assert.False(doesStationaryStoreExistsAfter);
    }
}
