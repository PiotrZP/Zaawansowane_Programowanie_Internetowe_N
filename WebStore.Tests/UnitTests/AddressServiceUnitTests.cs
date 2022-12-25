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
    public class AddressServiceUnitTests : BaseUnitTests
    {
        private readonly IAddressService _addressService;
        public AddressServiceUnitTests(ApplicationDbContext dbContext,
        IAddressService addressService) : base(dbContext)
        {
            _addressService = addressService;
        }

        [Fact]
        public void GetAddressTest()
        {
            var address = _addressService.GetAddress(a => a.City == "Czestochowa");
            Assert.NotNull(address);
        }

        [Fact]
        public void GetMultipleAddressesTest()
        {
            var addresses = _addressService.GetAddresses(a => a.Id >= 1 && a.Id <= 3);
            Assert.NotNull(addresses);
            Assert.NotEmpty(addresses);
            Assert.Equal(3, addresses.Count());
        }

        [Fact]
        public void GetAllAddressesTest()
        {
            var addresses = _addressService.GetAddresses();
            Assert.NotNull(addresses);
            Assert.NotEmpty(addresses);
            Assert.Equal(addresses.Count(), addresses.Count());
        }

        [Fact]
        public void AddNewAddressTest()
        {
            var newAddressVm = new AddOrUpdateAddressVm()
            {
                City = "Tokyo",
                Street = "Tokijska",
                BuildingNumber = 34,
                ZipCode = "52-600"
            };
            var createdAddress = _addressService.AddOrUpdateAddress(newAddressVm);
            Assert.NotNull(createdAddress);
            Assert.Equal("Tokijska", createdAddress.Street);

        }

        [Fact]
        public void UpdateAddressTest()
        {
            var updateAddressVm = new AddOrUpdateAddressVm()
            {
                Id = 1,
                City = "Czestochowa",
                Street = "Czestochowska",
                BuildingNumber = 12,
                ZipCode = "42-200"
            };
            var editedAddressVm = _addressService.AddOrUpdateAddress(updateAddressVm);
            Assert.NotNull(editedAddressVm);
            Assert.Equal("Czestochowska", editedAddressVm.Street);
            Assert.Equal(12, editedAddressVm.BuildingNumber);
        }
    }
}