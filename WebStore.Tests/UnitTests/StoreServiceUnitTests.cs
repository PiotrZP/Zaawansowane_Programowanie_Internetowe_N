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
namespace WebStore.Tests.UnitTests { 
    public class StoreServiceUnitTests : BaseUnitTests { 
        private readonly IStoreService _storeService;
        public StoreServiceUnitTests (ApplicationDbContext dbContext, 
        IStoreService storeService) : base (dbContext) { 
            _storeService = storeService; 
        } 
        
        [Fact]
        public void AddStoreTest () {
            var newStore = new AddOrUpdateStoreVm () { 
                Id = 1,
                Address = {},
                AddressId = 1,
                Orders = {},
                ArrangementNumber = 123,
                StationaryStoreEmployees = {},
            }; 
            var createdStore = _storeService.AddOrUpdateStore (newStore); 
            Assert.NotNull (createdStore);
            Assert.Equal (1, createdStore.Id);
        }

        [Fact]
        public void UpdateStoreTest () { 
            var editedStore = new AddOrUpdateStoreVm () { 
                Id = 1,
                Address = {},
                AddressId = 1,
                Orders = {},
                ArrangementNumber = 123,
                StationaryStoreEmployees = {},
            }; 
            var editedOrderVm = _storeService.AddOrUpdateStore (editedStore); 
            Assert.NotNull (editedStore);
            Assert.Equal (1, editedStore.Id); 
            Assert.Equal (100.00, editedOrderVm.ArrangementNumber); 
        } 

        [Fact]
        public void GetStoreTest () { 
            var store = _storeService.GetStore (p => p.ArrangementNumber == 100.00);
            Assert.NotNull (store); 
        } 
    }
}