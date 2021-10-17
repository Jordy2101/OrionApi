using ORIONDEV.SERVICES.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.SERVICES.Dto
{
    public class CompanyDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Rnc { get; set; }
    }
}
