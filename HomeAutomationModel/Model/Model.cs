using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeAutomationModel.Model
{
    [Table("model")]
    public class ModelDevice
    {
        [Key]
        [Column("model_id")]
        public int ModelDevice_Id { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("port")]
        public int Port { get; set; }
    }
}
