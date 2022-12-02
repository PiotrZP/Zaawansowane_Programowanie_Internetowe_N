using WebStore.Services.ConcreteServices;
using WebStore.Services.Interfaces;

namespace WebStore.Web.Extensions;
public static class DomainServicesExtensions
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IStoreService, StoreService>();
        services.AddTransient<IAddressService, AddressService>();
        services.AddTransient<IInvoiceService, InvoiceService>();
    }
}
