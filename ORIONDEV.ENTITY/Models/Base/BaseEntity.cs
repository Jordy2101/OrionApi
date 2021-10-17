using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORIONDEV.ENTITY.Models.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }
    }
}
