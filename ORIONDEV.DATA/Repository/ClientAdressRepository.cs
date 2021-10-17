using ORIONDEV.DATA.Base;
using ORIONDEV.DATA.DBContexts;
using ORIONDEV.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.DATA.Repository
{
    public class ClientAdressRepository : BaseRepository<ClientAdress>
    {
        public ClientAdressRepository(OrionDevDataContext ctx) : base(ctx)
        {

        }
    }
}
