using AutoMapper;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;


namespace WebStore.Services.Configuration{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<AddOrUpdateProductVm, Product>();
            CreateMap<ProductVm, Product>();
            CreateMap<Product, ProductVm>();
        
            
        }
    }
}