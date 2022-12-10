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
        public void GetAddressTest () { 
            var address = _addressService.GetAddress (a => a.City == "Czestochowa"); 
            Assert.NotNull (address); 
        } 
        
        [Fact] 
        public void GetMultipleAddressTest () { 
            var addresses = _addressService.GetAddresses (a => a.Id >= 1 && a.Id <= 2); 
            Assert.NotNull (addresses); 
            Assert.NotEmpty (addresses); 
            Assert.Equal (2, addresses.Count ()); 
        } 

        [Fact] 
        
        public void GetAllAddressTest () { 
            var addresses = _addressService.GetAddresses (); 
            Assert.NotNull (addresses); 
            Assert.NotEmpty (addresses); 
            Assert.Equal (addresses.Count (), addresses.Count ()); 
        } 
        
        [Fact] 
        
        public void AddNewAddressTest () { 
            var newAddressVm = new AddOrUpdateAddressVm () { 
                Id = 1,
                Street = "Kaliska",
                BuildingNumber = 12,
                City = "Czestochowa",
                ZipCode = "98300"
            }; 
                var createdAddress = _addressService.AddOrUpdateAddress (newAddressVm); 
                Assert.NotNull (createdAddress); 
                Assert.Equal ("Kaliska", createdAddress.Street); 
                
        }

        [Fact]

        public void UpdateAddressTest () { 
            var updateAddressVm = new AddOrUpdateAddressVm () { 
                Id = 1,
                Street = "Jasnorzewskiej",
                BuildingNumber = 23,
                City = "Czestochowa",
                ZipCode = "98300"
            }; 
            var editedAddressVm = _addressService.AddOrUpdateAddress (updateAddressVm); 
            Assert.NotNull (editedAddressVm); 
            Assert.Equal ("Jasnorzewskiej", editedAddressVm.Street); 
            Assert.Equal (23, editedAddressVm.BuildingNumber); 
        } 
    }
}