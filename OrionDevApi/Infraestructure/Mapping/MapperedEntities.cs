using AutoMapper;
using ORIONDEV.ENTITY.Models;
using ORIONDEV.SERVICES.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionDevApi.Infraestructure.Mapping
{
    public class MapperedEntities
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyDto>().ReverseMap();
                cfg.CreateMap<Client, ClientDto>().ForMember(c => c.CompanyDto, opt => opt.MapFrom(c => c.Company)).ReverseMap();
                cfg.CreateMap<ClientAdress, ClientAdressDto>().ForMember(c => c.ClientDto, opt => opt.MapFrom(c => c.Client)).ReverseMap();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }

    }
}
