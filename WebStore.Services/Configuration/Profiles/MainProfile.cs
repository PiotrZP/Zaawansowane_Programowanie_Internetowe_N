using AutoMapper;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Configuration.Profiles;
public class MainProfile : Profile
{
    public MainProfile()
    {
        CreateMap<AddOrUpdateAddressVm, Address>();
        CreateMap<Address, AddOrUpdateAddressVm>();
        CreateMap<AddOrUpdateInvoiceVm, Invoice>();
        CreateMap<Invoice, AddOrUpdateInvoiceVm>();
        CreateMap<AddOrUpdateOrderVm, Order>();
        CreateMap<Order, AddOrUpdateOrderVm>();
        CreateMap<AddOrUpdateProductVm, Product>();
        CreateMap<Product, AddOrUpdateProductVm>();
        CreateMap<AddOrUpdateStoreVm, StationaryStore>();
        CreateMap<StationaryStore, AddOrUpdateStoreVm>();

        CreateMap<Address, AddressVm>();
        CreateMap<AddressVm, Address>();

        CreateMap<CategoryVm, Category>();
        CreateMap<Category, CategoryVm>();

        CreateMap<InvoiceVm, Invoice>();
        CreateMap<Invoice, InvoiceVm>();

        CreateMap<OrderVm, Order>();
        CreateMap<Order, OrderVm>()
            .ForMember(dest => dest.Products, x => x
            .MapFrom(src => src.OrderProducts
            .Select(y => y.Product != null ? y.Product : null)));

        CreateMap<ProductStock, ProductStockVm>();
        CreateMap<ProductStockVm, ProductStock>();

        CreateMap<ProductVm, Product>();
        CreateMap<Product, ProductVm>()
            .ForMember(dest => dest.Orders, x => x
            .MapFrom(src => src.OrderProducts
            .Select(y => y.Order != null ? y.Order : null)));

        CreateMap<StationaryStoreEmployeeVm, StationaryStore>();

        CreateMap<StationaryStoreVm, StationaryStore>();
        CreateMap<StationaryStore, StationaryStoreVm>();

        CreateMap<SupplierVm, Supplier>();
    }

}