using ORIONDEV.DATA.Base;
using ORIONDEV.DATA.DBContexts;
using ORIONDEV.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORIONDEV.DATA.Repository
{
    public class CompanyRepository : BaseRepository<Company>
    {
        public CompanyRepository(OrionDevDataContext ctx) : base(ctx)
        {

        } 
    }
}
