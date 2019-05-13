using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeAutomationModel.Model
{
    [Table("device")]
    public class Device
    {

        [Key]
        [Column("device_id")]
        public int Device_Id { get; set; }

        [Column("ip")]
        public string IP { get; set; }

        [Column("model_id")]
        public int ModelId { get; set; }

        [ForeignKey("ModelId")]
        public ModelDevice ModelDevice { get; set; }

        [Column("area_id")]
        public int AreaId { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }

    }
}
