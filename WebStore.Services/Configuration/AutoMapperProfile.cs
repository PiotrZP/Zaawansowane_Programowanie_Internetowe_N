using AutoMapper;
using WebStore.Model.Models;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Configuration;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<InvoiceVm, Invoice>();
        CreateMap<Invoice, InvoiceVm>();
        CreateMap<AddOrUpdateInvoiceVm, Invoice>();

        CreateMap<OrderVm, Order>();
        CreateMap<Order, OrderVm>()
            .ForMember(dest => dest.Products, x => x
            .MapFrom(src => src.OrderProducts != null ? src.OrderProducts
            .Select(y => y.Product) : null));
        CreateMap<AddOrUpdateOrderVm, Order>();

        CreateMap<ProductVm, Product>();
        CreateMap<Product, ProductVm>()
            .ForMember(dest => dest.Orders, x => x
            .MapFrom(src => src.OrderProducts != null ? src.OrderProducts
            .Select(y => y.Order) : null));
        CreateMap<AddOrUpdateProductVm, Product>();

        CreateMap<StationaryStoreVm, StationaryStore>();
        CreateMap<StationaryStore, StationaryStoreVm>();
        CreateMap<AddOrUpdateStationaryStoreVm, StationaryStore>();

        CreateMap<AddressVm, Address>();
        CreateMap<Address, AddressVm>();
        CreateMap<AddOrUpdateAddressVm, Address>();

        CreateMap<StationaryStoreEmployee, StationaryStoreEmployeeVm>();
        CreateMap<CategoryVm, Category>();
        CreateMap<SupplierVm, Supplier>();
        CreateMap<Customer, CustomerVm>();
        CreateMap<Category, CategoryVm>();
        CreateMap<ProductStockVm, ProductStock>();
        CreateMap<ProductStock, ProductStockVm>();
    }
}