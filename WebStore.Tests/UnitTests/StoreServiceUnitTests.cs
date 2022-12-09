using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;
namespace WebStore.Tests.UnitTests
{
  public class StoreServiceUnitTests : BaseUnitTests
  {
    private readonly IStoreService _storeService;
    public StoreServiceUnitTests(WSDbContext dbContext,
    IStoreService storeService) : base(dbContext)
    {
      _storeService = storeService;
    }
    [Fact]
    public void GetStoreTest()
    {
      var store = _storeService.GetStationaryStore(s => s.Name == "XYZ");
      Assert.NotNull(store);
    }
    [Fact]
    public void GetMultipleStoreTest()
    {
      var stores = _storeService.GetStationaryStores(s => s.Id >= 1 && s.Id <= 2);
      Assert.NotNull(stores);
      Assert.NotEmpty(stores);
      Assert.Equal(2, stores.Count());
    }
    [Fact]
    public void GetAllStoresTest()
    {
      var stores = _storeService.GetStationaryStores();
      Assert.NotNull(stores);
      Assert.NotEmpty(stores);
      Assert.Equal(stores.Count(), stores.Count());
    }
    [Fact]
    public void AddNewStoreTest()
    {
      var newStoreVm = new AddOrUpdateStationaryStoreVm()
      {
        Name = "123",
      };
      var createdStore = _storeService.AddOrUpdateStationaryStore(newStoreVm);
      Assert.NotNull(createdStore);
      Assert.Equal("123", createdStore.Name);
    }
    [Fact]
    public void UpdateStoreTest()
    {
      var updateStoreVm = new AddOrUpdateStationaryStoreVm()
      {
        Id = 2,
        Name = "999",
      };
      var editedStoreVm = _storeService.AddOrUpdateStationaryStore(updateStoreVm);
      Assert.NotNull(editedStoreVm);
      Assert.Equal("999", editedStoreVm.Name);
      Assert.Equal(2, editedStoreVm.Id);
    }
  }
}