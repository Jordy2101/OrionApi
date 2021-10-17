using ORIONDEV.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.SERVICES.Dto
{
    public class ClientClientAdress
    {
        public string Name { get; set; }
        public int IdCompany { get; set; }
        public List<ClientAdress> ClientAdressList { get; set; }
    }
}
