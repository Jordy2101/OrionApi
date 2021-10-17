using ORIONDEV.ENTITY.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORIONDEV.ENTITY.Models
{
    public class Client : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("IdCompany")]
        public int IdCompany { get; set; }


        [ForeignKey("IdCompany")]
        public virtual Company Company { get; set; }
    }
}
