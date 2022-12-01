using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;
namespace WebStore.Tests.UnitTests
{
    public class StoreServiceUnitTests : BaseUnitTests
    {
        private readonly IStoreService _storeService;

        public StoreServiceUnitTests(ApplicationDbContext dbContext, IStoreService storeService) : base(dbContext){
            _storeService = storeService;
        }

        [Fact]
        public void GetStoreTest()
        {
            var store = _storeService.GetStore(s => s.Id == 1);
            Assert.NotNull(store);
        }
        // [Fact]
        public void GetMultipleStoresTest()
        {
        var stores = _storeService.GetStores(s => s.Id >=1 && s.Id<=2);
        Assert.NotEmpty(stores);
        Assert.NotNull(stores);
        Assert.Equal(2,stores.Count());
        }
        // [Fact]
        public void GetAllStoresTest()
        {
            var stores = _storeService.GetStores();
            Assert.NotEmpty(stores);
            Assert.NotNull(stores);
        }
        // [Fact]
        public void AddNewStoreTest()
        {
            var newStoreVm = new AddOrUpdateStoreVm()
            {
                Name = "Mleczny",
                AddressId = 83
            };

        var createdStore = _storeService.AddOrUpdateStore(newStoreVm);
        Assert.NotNull(createdStore);
        Assert.Equal("Mleczny",createdStore.Name);
        }
        // [Fact]
        public void UpdateStoreTest()
        {
            var updateStoreVm = new AddOrUpdateStoreVm()
            {
                Id = 1,
                Name = "Mięsny",
                AddressId = 3
            };
        var store = _storeService.AddOrUpdateStore(updateStoreVm);
        Assert.NotNull(store);
        Assert.Equal("Mięsny", store.Name);
        }
        // [Fact]
        public void DeleteStoreTest()
        {
            var store = _storeService.DeleteStore(s => s.Id == 2);
            Assert.NotNull(store);
        }

    }
}