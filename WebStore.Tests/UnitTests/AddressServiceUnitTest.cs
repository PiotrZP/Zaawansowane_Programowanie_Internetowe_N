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
    public class AddressServiceUnitTest : BaseUnitTests
    {
        private readonly IAddressService _addressService;
        public AddressServiceUnitTest(ApplicationDbContext dbContext, IAddressService addressService) : base(dbContext)
        {
            _addressService = addressService;
        }
        [Fact]
        public void GetAddressTest()
        {
            var address = _addressService.GetAddress(a => a.Country == "Polska");
            Assert.NotNull(address);
        }
        [Fact]
        public void GetMultipleAddressesTest()
        {
            var addresses = _addressService.GetAddresses(a => a.Id >= 1 && a.Id <= 3);
            Assert.NotEmpty(addresses);
            Assert.NotNull(addresses);
            Assert.Equal(3, addresses.Count());
        }
        [Fact]
        public void GetAllAdressesTest()
        {
            var addresses = _addressService.GetAddresses();
            Assert.NotNull(addresses);
            Assert.NotEmpty(addresses);

        }
        [Fact]
        public void AddNewAddressTest()
        {
            var newAddress = new AddOrUpdateAddressVm()
            {
                City = "Hajduszoboszlo",
                Country = "Wegry",
                BuildingNumber = 121,
                ZipCode = "11-111",
                Street = "Fancy"
            };
            var createAddress = _addressService.AddOrUpdateAddress(newAddress);
            Assert.NotNull(createAddress);
            Assert.Equal("Hajduszoboszlo", createAddress.City);
        }
        [Fact]
        public void UpdateAddressTest()
        {
            var newAddress = new AddOrUpdateAddressVm()
            {
                Id = 3,
                City = "Stolec",
                Country = "Polska",
                BuildingNumber = 45,
                ZipCode = "11-111",
                Street = "Nudna"
            };
            var updateAddress = _addressService.AddOrUpdateAddress(newAddress);
            Assert.NotNull(updateAddress);
            Assert.Equal("Stolec", updateAddress.City);
        }
        [Fact]
        public void DeleteAddressTest()
        {
            var deleteAddress = _addressService.DeleteAddress(a => a.Id == 3);
            Assert.NotNull(deleteAddress);
        }

    }
}