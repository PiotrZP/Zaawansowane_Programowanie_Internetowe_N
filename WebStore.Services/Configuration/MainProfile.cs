using AutoMapper;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;


namespace WebStore.Services.Configuration
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<AddOrUpdateAddressVm, Address>();
            CreateMap<AddressVm, Address>();
            CreateMap<Address, AddressVm>();

            CreateMap<AddOrUpdateOrderVm, Order>();
            CreateMap<OrderVm, Order>();
            CreateMap<Order, OrderVm>();

            CreateMap<AddOrUpdateInvoiceVm, Invoice>();
            CreateMap<InvoiceVm, Invoice>();
            CreateMap<Invoice, InvoiceVm>();

            CreateMap<AddOrUpdateStationaryStoreVm, StationaryStore>();
            CreateMap<StationaryStoreVm, StationaryStore>();
            CreateMap<StationaryStore, StationaryStoreVm>();
        }
    }
}