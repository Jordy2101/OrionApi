using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.SERVICES.Dto.Base
{
    public class BaseEntityDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
