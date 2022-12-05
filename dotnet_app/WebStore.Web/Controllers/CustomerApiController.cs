using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces; 
using WebStore.ViewModels.VM;

namespace WebStore.Web.Controllers;

public class CustomerApiController : BaseApiController
{
    public CustomerApiController(ILogger logger, IMapper mapper) : base(logger, mapper)
    {
    }

    // CRUD actions
}