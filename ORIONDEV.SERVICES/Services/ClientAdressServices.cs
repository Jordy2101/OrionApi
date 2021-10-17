using AutoMapper;
using ORIONDEV.COMMON.Filter;
using ORIONDEV.COMMON.Paged;
using ORIONDEV.DATA.Base.Interface;
using ORIONDEV.ENTITY.Models;
using ORIONDEV.SERVICES.Base;
using ORIONDEV.SERVICES.Dto;
using ORIONDEV.SERVICES.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORIONDEV.SERVICES.Services
{
    public class ClientAdressServices : ServicesBase<ClientAdress>, IClientAdressServices
    {
        readonly IMapper mapper;
        public ClientAdressServices(IBaseRepository<ClientAdress> repository, IMapper _mapper) : base(repository)
        {
            mapper = _mapper;

        }
        public override int Create(ClientAdress entity)
        {
            if (base.Exist(c => c.IdCliente == entity.IdCliente && c.Adress == entity.Adress)) throw new ArgumentException("No se puede duplicar una direccion");
            return base.Create(entity);
        }
        public override ClientAdress Update(ClientAdress entity)
        {
            if (base.Exist(c => c.IdCliente == entity.IdCliente && c.Adress == entity.Adress && c.Id != entity.Id)) throw new ArgumentException("No se puede duplicar una direccion");
            return base.Update(entity);
        }
        public object GetPaged(ClientAdressFilter filter)
        {
            try
            {
                var data = base.FindAll().Where(c=> c.IdCliente == filter.IdClient);
                var list = mapper.ProjectTo<ClientAdressDto>(data);
                var result = PagedList<ClientAdressDto>.Create(list, filter.PageNumber, filter.PageSize);
                if (result == null) { throw new ArgumentException("No existen registros con los parametros de busqueda"); }
                var pagination = new
                {
                    totalCount = result.TotalCount,
                    pageSize = result.PageSize,
                    currentPage = result.CurrentPage,
                    totalPage = result.TotalPages,
                    HasNext = result.HasNext,
                    HasPrevious = result.HasPrevious,
                    data = result
                };

                return pagination;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
