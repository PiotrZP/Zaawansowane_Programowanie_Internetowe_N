using AutoMapper;
using WebStore.Model.Models;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Configuration;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddOrUpdateProductVm, Product>();
        CreateMap<CategoryVm, Category>();
        CreateMap<CustomerVm, Customer>();
        CreateMap<InvoiceVm, Invoice>();
        CreateMap<OrderVm, Order>();
        CreateMap<ProductStockVm, ProductStock>();
        CreateMap<ProductVm, Product>();
        CreateMap<UserVm, User>();
        CreateMap<ShippingAddressVm, ShippingAddress>();
        CreateMap<StationaryStoreVm, StationaryStore>();
        CreateMap<StationaryStoreEmployeeVm, StationaryStore>();
        CreateMap<SupplierVm, Supplier>();

    }

}