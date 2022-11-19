using WebStore.DAL.EF;
using WebStore.Services.Interface;
using WebStore.ViewModels.Vm;

namespace WebStore.Test.UnitTest
{
    public class AddressServiceUnitTest : BaseUnitTest
    {
        private readonly IAddressService _addressService;
        public AddressServiceUnitTest(ApplicationDbContext dbContext, IAddressService addressService) 
        : base(dbContext)
        {
            _addressService = addressService;
        }

        [Fact]
        public void GetAddressTest()
        {
            
            var address = _addressService.GetAddress(a => a.City  == "Wisla");
            Assert.NotNull (address); 
        }

        [Fact]
        public void GetMultipleAddressTest()
        {
            var addresses = _addressService.GetAddresses(a => a.Id >= 1 && a.Id <= 2);
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
            Assert.Equal(DbContext.Addresses.Count(), addresses.Count());
        }

        [Fact]
        public void AddNewAddressTest()
        {
            var newAddressVm = new AddOrUpdateAddressVm
            {
                City = "Krakow",
                Street = "Webowa",
                ZipCode = 93821
            };
            var createAddress = _addressService.AddOrUpdateAddress(newAddressVm);
            Assert.NotNull(createAddress);
            Assert.Equal("Webowa", createAddress.Street);
        }

        [Fact]
        public void UpdateAddressTest()
        {
            var updateAddressVm = new AddOrUpdateAddressVm()
            {
                Id = 2,
                City = "Ludz",
                Street = "Piracka",
                ZipCode = 85612
            };

            var editedAddressVm = _addressService.AddOrUpdateAddress (updateAddressVm);
            Assert.NotNull(editedAddressVm);
            Assert.Equal(85612, editedAddressVm.ZipCode);
        }

        [Fact]
        public void DeleteAddressTest()
        {
            var changeAddresses = _addressService.DeleteAddress(a => a.Id == 1);
            Assert.Equal(1, changeAddresses.Count());
        }
    }
}