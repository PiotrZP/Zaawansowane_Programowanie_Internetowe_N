using AutoMapper;
using Webstore.Model;
using WebStore.Model.DataModels;
using WebStore.ViewModels.Vm;
namespace WebStore.Services.Configuration.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            //AutoMapper maps
            CreateMap<Product, ProductVm>(); //map from Product(src) to ProductVm(dst)
            CreateMap<AddOrUpdateProductVm, Product>();
            CreateMap<ProductVm, AddOrUpdateProductVm>();    

              //Order maps
            CreateMap<Order, OrderVm>(); //map from Product(src) to ProductVm(dst)
            CreateMap<AddOrUpdateOrderVm, Order>();
            CreateMap<OrderVm, AddOrUpdateOrderVm>();  

             //Starionary Store maps
            CreateMap<StationaryStore, StationaryStoreVm>(); //map from StationaryStore(src) to StationaryStoreVm(dst)
            CreateMap<AddOrUpdateStationaryStoreVm, StationaryStore>();
            CreateMap<StationaryStoreVm, AddOrUpdateStationaryStoreVm>();  

              //Address maps
            CreateMap<StationaryStoreAddress, AddressVm>(); //map from Address(src) to AddressVm(dst)
            CreateMap<AddOrUpdateAddressVm, StationaryStoreAddress>();
            CreateMap<AddressVm, AddOrUpdateAddressVm>();  

             //Invoice maps
            CreateMap<Invoice, InvoiceVm>(); //map from Invoice(src) to InvoiceVm(dst)
            CreateMap<AddOrUpdateInvoiceVm, Invoice>();
            CreateMap<InvoiceVm, AddOrUpdateInvoiceVm>();  
        }
    }
}