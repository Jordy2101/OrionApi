using ORIONDEV.SERVICES.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.SERVICES.Dto
{
    public class ClientAdressDto : BaseEntityDto
    {
        public int IdCliente { get; set; }
        public string Adress { get; set; }

        public virtual ClientDto ClientDto { get; set; }
    }
}
