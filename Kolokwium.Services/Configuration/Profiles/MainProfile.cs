using AutoMapper;
using Kolokwium.Model.Models;
using Kolokwium.ViewModels.VM;

namespace Kolokwium.Services.Configuration.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            //AutoMapper map

            CreateMap<AddOrUpdateProductVm, Product>();
            CreateMap<ProductVm, Product>();
            CreateMap<Product, ProductVm>();

            CreateMap<AddOrUpdateCategoryVm, Category>();
            CreateMap<CategoryVm, Category>();
            CreateMap<Category, CategoryVm>();

            CreateMap<AddOrUpdateInvoiceVm, Invoice>();
            CreateMap<InvoiceVm, Invoice>();
            CreateMap<Invoice, InvoiceVm>();

            CreateMap<AddOrUpdateAddressVm, Address>();
            CreateMap<AddressVm, Address>();
            CreateMap<Address, AddressVm>();

            CreateMap<AddOrUpdateOrderVm, Order>();
            CreateMap<OrderVm, Order>();
            CreateMap<Order, OrderVm>();

            CreateMap<AddOrUpdateStoreVm, StationaryStore>();
            CreateMap<StoreVm, StationaryStore>();
            CreateMap<StationaryStore, StoreVm>();
        }
    }
}