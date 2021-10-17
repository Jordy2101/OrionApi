using ORIONDEV.ENTITY.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORIONDEV.ENTITY.Models
{
    public class Company : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Rnc")]
        public string Rnc { get; set; }
    }
}
