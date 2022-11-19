using AutoMapper;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Configuration;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CategoryVm, Category>();
        CreateMap<InvoiceVm, Invoice>();
        CreateMap<OrderVm, Order>();
        CreateMap<ProductStockVm, ProductStock>();
        CreateMap<ProductVm, Product>();
        CreateMap<ShippingAddressVm, ShippingAddress>();
        CreateMap<SupplierVm, Supplier>();
        CreateMap<Category, CategoryVm>();
        CreateMap<Customer, CustomerVm>();
        CreateMap<Invoice, InvoiceVm>();

        CreateMap<Order, OrderVm>()
            .ForMember(dest => dest.Products, x => x
            .MapFrom(src => src.OrderProducts
            .Select(y => y.Product != null ? y.Product : null)));

        CreateMap<ProductStock, ProductStockVm>();
        CreateMap<Product, ProductVm>()
            .ForMember(dest => dest.Orders, x => x
            .MapFrom(src => src.OrderProducts
            .Select(y => y.Order != null ? y.Order : null)));

        CreateMap<Product, AddOrUpdateProductVm>();
        CreateMap<AddOrUpdateProductVm, Product>();
        CreateMap<ShippingAddress, ShippingAddressVm>();
    }
}