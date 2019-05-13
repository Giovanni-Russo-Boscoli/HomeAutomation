using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeAutomationModel.Model
{
    [Table("area")]
    public class Area
    {
        [Key]
        [Column("area_id")]
        public int Area_Id { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
