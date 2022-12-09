using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;


namespace WebStore.Services.Configuration
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<AddOrUpdateProductVm, Product>();
            CreateMap<ProductVm, Product>();
            CreateMap<Product, ProductVm>();

            CreateMap<AddOrUpdateInvoiceVm, Invoice>();
            CreateMap<InvoiceVm, Invoice>();
            CreateMap<Invoice, InvoiceVm>();

            CreateMap<AddOrUpdateOrderVm, Order>();
            CreateMap<OrderVm, Order>();
            CreateMap<Order, OrderVm>();

            CreateMap<AddOrUpdateAddressVm, Address>();
            CreateMap<AddressVm, Address>();
            CreateMap<Address, AddressVm>();

            CreateMap<AddOrUpdateStoreVm, StationaryStore>();
            CreateMap<StoreVm, StationaryStore>();
            CreateMap<StationaryStore, StoreVm>();
        }
    }
}