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
    public class AddressServiceUnitTests : BaseUnitTests { 
        private readonly IAddressService _addressService;
        public AddressServiceUnitTests (ApplicationDbContext dbContext, 
        IAddressService addressService) : base (dbContext) { 
            _addressService = addressService; 
        } 
        
        [Fact]
        public void AddAddressTest () {
            var newAdddress = new AddOrUpdateAddressVm () { 
                Id = 1,
                StreetName = "Testowa",
                StreetNumber = 2,
                City = "Warszawa",
                PostCode = "00-000"
            }; 
            var createdAddress = _addressService.AddOrUpdateAddress (newAdddress); 
            Assert.NotNull (createdAddress);
            Assert.Equal (1, createdAddress.Id);
        }

        [Fact]
        public void UpdateAddressTest () { 
            var editedStore = new AddOrUpdateAddressVm () { 
                Id = 1,
                StreetName = "Testowa2",
                StreetNumber = 2,
                City = "Warszawa",
                PostCode = "00-000"
            }; 
            var editedStoreVm = _addressService.AddOrUpdateAddress (editedStore); 
            Assert.NotNull (editedStore);
            Assert.Equal (1, editedStore.Id); 
            Assert.Equal ("Testowa2", editedStoreVm.StreetName); 
        } 

        [Fact]
        public void GetAddressTest () { 
            var store = _addressService.GetAddress (p => p.StreetName == "Testowa2");
            Assert.NotNull (store); 
        } 
    }
}