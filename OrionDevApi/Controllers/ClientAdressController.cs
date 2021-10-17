using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORIONDEV.COMMON.Filter;
using ORIONDEV.ENTITY.Models;
using ORIONDEV.SERVICES.Base.Interface;
using ORIONDEV.SERVICES.Dto;
using ORIONDEV.SERVICES.Interface;
using OrionDevApi.Attributes;
using OrionDevApi.Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionDevApi.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAdressController : BaseApiController<ClientAdress, ClientAdressDto, IServicesBase<ClientAdress>>
    {
        readonly IClientAdressServices services;
        public ClientAdressController(IServicesBase<ClientAdress> manager, IClientAdressServices _services, IMapper Mapper) : base(manager, Mapper)
        {
            services = _services;
        }
        [HttpGet]
        [Route("GetPaged")]
        public ActionResult GetPagedDetail([FromQuery] ClientAdressFilter filter)
        {
            return Ok(services.GetPaged(filter));
        }
    }
}
