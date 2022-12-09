using AutoMapper;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Configuration;
public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    CreateMap<AddOrUpdateProductVm, Product>();
    CreateMap<ProductVm, Product>();
    CreateMap<Product, ProductVm>();

    CreateMap<AddOrUpdateOrderVm, Order>();
    CreateMap<OrderVm, Order>();
    CreateMap<Order, OrderVm>();

    CreateMap<AddOrUpdateStationaryStoreVm, StationaryStore>();
    CreateMap<StationaryStoreVm, StationaryStore>();
    CreateMap<StationaryStore, StationaryStoreVm>();

    CreateMap<AddOrUpdateInvoiceVm, Invoice>();
    CreateMap<InvoiceVm, Invoice>();
    CreateMap<Invoice, InvoiceVm>();

    CreateMap<AddOrUpdateAddressVm, Address>();
    CreateMap<AddressVm, Address>();
    CreateMap<Address, AddressVm>();
  }
}