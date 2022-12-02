using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Configuration.Profiles {
    public class MainProfile : Profile {
        public MainProfile () {
            CreateMap<AddOrUpdateProductVm, Product>();
            CreateMap<ProductVm, Product>();
            CreateMap<Product, ProductVm>();

            CreateMap<AddOrUpdateInvoiceVm, Invoice>();
            CreateMap<GetInvoiceVm, Invoice>();
            CreateMap<InvoiceVm, Invoice>();
            CreateMap<Invoice, InvoiceVm>();

            CreateMap<AddOrUpdateOrderVm, Order>();
            CreateMap<DeleteOrderVm, Order>();
            CreateMap<OrderVm, Order>();
            CreateMap<Order, OrderVm>();

            CreateMap<AddOrUpdateStoreVm, StationaryStore>();
            CreateMap<GetStoreVm, StationaryStore>();
            CreateMap<AddressVm, Address>();
            CreateMap<Address, AddressVm>();

            CreateMap<StationaryStoreEmployeeVm, StationaryStoreEmployee>();
            CreateMap<StationaryStoreEmployee, StationaryStoreEmployeeVm>();

            CreateMap<AddOrUpdateAddressVm, Address>();
        }
    }
}