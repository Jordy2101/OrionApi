using ORIONDEV.SERVICES.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.SERVICES.Dto
{
    public class ClientDto : BaseEntityDto
    {
        public string Name { get; set; }
        public int IdCompany { get; set; }

        public virtual CompanyDto CompanyDto { get; set; }
    }
}
