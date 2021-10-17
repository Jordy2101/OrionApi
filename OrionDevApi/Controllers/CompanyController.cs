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
    public class CompanyController : BaseApiController<Company, CompanyDto, IServicesBase<Company>>
    {
        readonly ICompanyServices services;
        public CompanyController(IServicesBase<Company> manager, ICompanyServices _services, IMapper Mapper) : base(manager, Mapper)
        {
            services = _services;
        }
        [HttpGet]
        [Route("GetPaged")]
        public ActionResult GetPagedDetail([FromQuery] CompanyFilter filter)
        {
            return Ok(services.GetPaged(filter));
        }
    }
}
