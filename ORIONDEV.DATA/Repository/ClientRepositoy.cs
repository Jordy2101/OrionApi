using ORIONDEV.DATA.Base;
using ORIONDEV.DATA.DBContexts;
using ORIONDEV.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.DATA.Repository
{
    public class ClientRepositoy : BaseRepository<Client>
    {
        public ClientRepositoy(OrionDevDataContext ctx) : base(ctx)
        {

        }
    }
}
