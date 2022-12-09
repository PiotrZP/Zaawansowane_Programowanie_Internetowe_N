using System.Reflection;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;
namespace WebStore.Tests.UnitTests
{
  public class AddressServiceUnitTests : BaseUnitTests
  {
    private readonly IAddressService _addressService;
    public AddressServiceUnitTests(WSDbContext dbContext,
      IAddressService addressService) : base(dbContext)
    {
      _addressService = addressService;
    }
    [Fact]
    public void GetAddressTest()
    {
      var address = _addressService.GetAddress(a => a.PostCode == "97-500");
      Assert.NotNull(address);
    }
    [Fact]
    public void GetMultipleAddressTest()
    {
      var addresses = _addressService.GetAddresses(p => p.Id >= 1 && p.Id <= 2);
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
        StationaryStoreId = 3,
        City = "Bialystok",
        PostCode = "97-500",
        StreetName = "Zodiakalna",
        StreetNumber = 173
      };
      var createdAddress = _addressService.AddOrUpdateAddress(newAddressVm);
      Assert.NotNull(createdAddress);
      Assert.Equal("Bialystok", createdAddress.City);
    }
    [Fact]
    public void UpdateAddressTest()
    {
      var updateAddressVm = new AddOrUpdateAddressVm()
      {
        Id = 1,
        StationaryStoreId = 1,
        City = "Bialystok",
        PostCode = "97-500",
        StreetName = "Szkolna",
        StreetNumber = 18
      };
      var editedAddressVm = _addressService.AddOrUpdateAddress(updateAddressVm);
      Assert.NotNull(editedAddressVm);
      Assert.Equal("Bialystok", editedAddressVm.City);
      Assert.Equal(18, editedAddressVm.StreetNumber);
    }
  }
}
