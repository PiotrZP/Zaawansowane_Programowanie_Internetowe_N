using WebStore.DAL.DatabaseContext;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
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
            var address = _addressService.GetAddress(a => a.Id == 1003);
            Assert.NotNull(address);
        }

        [Fact]
        public void GetMultipleAddressTest()
        {
            var addresses = _addressService.GetAddresses(a => a.Country == "Poland");
            Assert.NotNull(addresses);
            Assert.NotEmpty(addresses);
            Assert.Equal(2, addresses.Count());
        }

        [Fact]

        public void GetAllAddressTest()
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
                Id = 0,
                Street = "Złota",
                BuildingNumber = 18,
                ApartmentNumber = 2,
                City = "Pabianice",
                ZipCode = "98-213"
            };
            var createdAddress = _addressService.AddOrUpdateAddress(newAddressVm);
            Assert.NotNull(createdAddress);
            Assert.Equal("Złota", createdAddress.Street);

        }

        [Fact]

        public void UpdateAddressTest()
        {
            var updateAddressVm = new AddOrUpdateAddressVm()
            {
                Id = 1003,
                Street = "Srebrna",
            };
            var editedAddressVm = _addressService.AddOrUpdateAddress(updateAddressVm);
            Assert.NotNull(editedAddressVm);
            Assert.Equal("Srebrna", editedAddressVm.Street);
        }
    }
}