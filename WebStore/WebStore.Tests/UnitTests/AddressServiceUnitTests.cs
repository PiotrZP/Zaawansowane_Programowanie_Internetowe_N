using Microsoft.EntityFrameworkCore;
using WebStore.DAL.DatabaseContext;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;

namespace WebStore.Tests.UnitTests;
public class AddressServiceUnitTests : BaseUnitTests
{
    private readonly IAddressService _service;
    private readonly WSDbContext _context;
    public AddressServiceUnitTests(WSDbContext dbContext,
        IAddressService AddressService) : base(dbContext)
    {
        _service = AddressService;
        _context = dbContext;
    }

    [Fact]
    public void GetAddressTest()
    {
        var address = _service.GetAddress(p => p.StreetName == "Szkolna");
        Assert.NotNull(address);
    }

    [Fact]
    public void GetMultipleAddresssTest()
    {
        var addresss = _service.GetAddresss(p => p.Id >= 1 && p.Id <= 2);
        Assert.NotNull(addresss);
        Assert.NotEmpty(addresss);
        Assert.Equal(2, addresss.Count());
    }

    [Fact]
    public void GetAllAddresssTest()
    {
        var addresss = _service.GetAddresss();
        Assert.NotNull(addresss);
        Assert.NotEmpty(addresss);
        Assert.Equal(addresss.Count(), addresss.Count());
    }

    [Fact]
    public void AddNewAddressTest()
    {
        var newAddressVm = new AddOrUpdateAddressVm()
        {
            CustomerId = 1,
            City = "OtherCity",
            StreetName = "MainStreet",
            StreetNumber = 112,
            PostCode = "20-221"
        };

        var createdAddress = _service.AddOrUpdateAddress(newAddressVm);
        Assert.NotNull(createdAddress);
        Assert.Equal("MainStreet", createdAddress.StreetName);
        Assert.Equal(112, createdAddress.StreetNumber);
    }

    [Fact]
    public void UpdateAddressTest()
    {
        var updateAddressVm = new AddOrUpdateAddressVm()
        {
            Id = 2,
            StationaryStoreId = 2,
            City = "StoreCityEdited",
            StreetName = "Boczna",
            StreetNumber = 1,
            PostCode = "42-999"
        };
        var editedAddressVm = _service.AddOrUpdateAddress(updateAddressVm);
        Assert.NotNull(editedAddressVm);
        Assert.Equal(1, editedAddressVm.StreetNumber);
        Assert.Equal("Boczna", editedAddressVm.StreetName);
    }

    [Fact]
    public async Task DeleteAddressTest()
    {
        int addressId = 3;

        bool doesAddressExistsBefore = await _context.Address.AnyAsync(x => x.Id == addressId);
        await _service.DeleteAddress(x => x.Id == addressId);
        bool doesAddressExistsAfter = await _context.Address.AnyAsync(x => x.Id == addressId);

        Assert.True(doesAddressExistsBefore);
        Assert.False(doesAddressExistsAfter);
    }
}
