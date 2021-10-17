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
    public class ClientController : BaseApiController<Client, ClientDto, IServicesBase<Client>>
    {
        readonly IClientServices services;
        public ClientController(IServicesBase<Client> manager, IClientServices _services,IMapper Mapper) : base(manager, Mapper)
        {
            services = _services;
        }
        [HttpGet]
        [Route("GetPaged")]
        public ActionResult GetPagedDetail([FromQuery] ClientFilter filter)
        {
            return Ok(services.GetPaged(filter));
        }
    }
}
