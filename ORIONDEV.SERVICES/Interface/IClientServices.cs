using ORIONDEV.COMMON.Filter;
using ORIONDEV.SERVICES.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.SERVICES.Interface
{
    public interface IClientServices
    {
        object GetPaged(ClientFilter filter);
        void CreateClient(ClientClientAdress dto);
    }
}
