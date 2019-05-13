using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeAutomationModel.Model
{
    [Table("type")]
    public class TypeDevice
    {
        [Key]
        [Column("type_id")]
        public int Type_Id { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
