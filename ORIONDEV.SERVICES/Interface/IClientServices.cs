using ORIONDEV.COMMON.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.SERVICES.Interface
{
    public interface IClientServices
    {
        object GetPaged(ClientFilter filter);
    }
}
