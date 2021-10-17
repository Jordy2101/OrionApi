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
    public class ClientServices : ServicesBase<Client>, IClientServices
    {
        readonly IMapper mapper;
        public ClientServices(IBaseRepository<Client> repository, IMapper _mapper) : base(repository)
        {
            mapper = _mapper;

        }
        public override int Create(Client entity)
        {
            if (base.Exist(c => c.Name == entity.Name && c.IdCompany == entity.IdCompany)) throw new ArgumentException("No se puede duplicar un cliente");
            return base.Create(entity);
        }
        public override Client Update(Client entity)
        {
            if (base.Exist(c => c.Name == entity.Name && c.IdCompany == entity.IdCompany && c.Id == entity.Id)) throw new ArgumentException("No se puede duplicar un cliente");
            return base.Update(entity);
        }
        public object GetPaged(ClientFilter filter)
        {
            try
            {
                var data = base.FindAll();
                if (filter.keyword != null)
                    data = data.Where(c => c.Name.Contains(filter.keyword));

                var list = mapper.ProjectTo<ClientDto>(data);
                var result = PagedList<ClientDto>.Create(list, filter.PageNumber, filter.PageSize);
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
