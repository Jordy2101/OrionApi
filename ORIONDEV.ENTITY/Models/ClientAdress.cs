using ORIONDEV.ENTITY.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORIONDEV.ENTITY.Models
{
    public class ClientAdress : BaseEntity
    {
        [Column("IdCliente")]
        public int IdCliente { get; set; }
        [Column("Adress")]
        public string Adress { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Client Client { get; set; }
    }
}
