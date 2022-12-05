using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Kolokwium.Web.Controllers
{
    public class CustomerApiController : BaseController
    {
        public CustomerApiController(ILogger logger, IMapper mapper) : base(logger, mapper)
        {
        }
    }
}