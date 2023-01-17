using Microsoft.EntityFrameworkCore;
using WebStore.DAL.DataAccess;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;
namespace WebStore.Tests.UnitTests;

public class AddressServiceUnitTests : BaseUnitTests
{
    private readonly IAddressService _addressService;
    private readonly ApplicationDbContext _dbContext;
    public AddressServiceUnitTests(ApplicationDbContext dbContext,
        IAddressService AddressService) : base(dbContext)
    {
        _addressService = AddressService;
        _dbContext = dbContext;
    }
    [Fact]
    public void GetAddressTest()
    {
        var address = _addressService.GetAddress(p => p.StreetName == "Główna");
        Assert.NotNull(address);
    }

    [Fact]
    public void GetMultipleAddresssTest()
    {
        var addresses = _addressService.GetAddresses(p => p.Id >= 1 && p.Id <= 2);
        Assert.NotNull(addresses);
        Assert.NotEmpty(addresses);
        Assert.Equal(2, addresses.Count());
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
            BillingCustomerId = 1,
            City = "City",
            StreetName = "Street",
            BuildingNumber = "32",
            ZipCode = "99-999"
        };

        var createdAddress = _addressService.AddOrUpdateAddress(newAddressVm);
        Assert.NotNull(createdAddress);
        Assert.Equal("Street", createdAddress.StreetName);
        Assert.Equal("32", createdAddress.BuildingNumber);
    }

    [Fact]
    public void UpdateAddressTest()
    {
        var updateAddressVm = new AddOrUpdateAddressVm()
        {
            Id = 1,
            ApartmentNumber = 2,
            BillingCustomerId = 1,
            City = "Town",
            StreetName = "Road",
            BuildingNumber = "32A",
            ZipCode = "00-999"
        };
        var editedAddressVm = _addressService.AddOrUpdateAddress(updateAddressVm);
        Assert.NotNull(editedAddressVm);
        Assert.Equal(2, editedAddressVm.ApartmentNumber);
        Assert.Equal("Town", editedAddressVm.StreetName);
        Assert.Equal("32A", editedAddressVm.BuildingNumber);
    }

    [Fact]
    public async Task DeleteAddressTest()
    {
        int addressId = 3;

        bool doesAddressExistsBefore = await _dbContext.Address.AnyAsync(x => x.Id == addressId);
        await _addressService.DeleteAddress(x => x.Id == addressId);
        bool doesAddressExistsAfter = await _dbContext.Address.AnyAsync(x => x.Id == addressId);

        Assert.True(doesAddressExistsBefore);
        Assert.False(doesAddressExistsAfter);
    }
}