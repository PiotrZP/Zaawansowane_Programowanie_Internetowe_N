using AutoMapper;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;
using System.Linq;

namespace WebStore.Services.Configuration.Profiles{
    public class MainProfile : Profile
    {
    public MainProfile()
    {
        //AutoMapper maps

        CreateMap<AddOrUpdateProductVm, Product>();
        //CreateMap<Product, AddOrUpdateProductVm>();
        CreateMap<ProductVm, Product>();
        CreateMap<Product, ProductVm>();

        CreateMap<AddOrUpdateOrderVm, Order>();
        //CreateMap<Order, AddOrUpdateOrderVm>();
        CreateMap<OrderVm, Order>();
        CreateMap<Order, OrderVm>();

        CreateMap<AddOrUpdateInvoiceVm, Invoice>();
        //CreateMap<Invoice, AddOrUpdateInvoiceVm>();
        CreateMap<InvoiceVm, Invoice>();
        CreateMap<Invoice, InvoiceVm>();

        CreateMap<AddOrUpdateStoreVm, StationaryStore>();
        //CreateMap<StationaryStore, AddOrUpdateStationaryStoreVm>();
        CreateMap<StoreVm, StationaryStore>();
        CreateMap<StationaryStore, StoreVm>();

        CreateMap<AddOrUpdateAddressVm, Address>();
        //CreateMap<Address, AddOrUpdateAddressVm>();
        CreateMap<AddressVm, Address>();
        CreateMap<Address, AddressVm>();

    }
}
}