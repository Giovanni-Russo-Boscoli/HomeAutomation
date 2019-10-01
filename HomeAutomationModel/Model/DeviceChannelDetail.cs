using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeAutomationModel.Model
{
    [Table("device_channel_details")]
    public class DeviceChannelDetail
    {

        [Key]
        [Column("device_channel_detail_id")]
        public int DeviceChannelDetail_Id { get; set; }


        [Column("device_id")]
        public int deviceId { get; set; }

        [ForeignKey("deviceId")]
        public Device Device { get; set; }


        [Column("type_id")]
        public int typeId { get; set; }

        [ForeignKey("typeId")]
        public TypeDevice TypeDevice { get; set; }


        [Column("action_id")]
        public int actionId { get; set; }

        [ForeignKey("actionId")]
        public Action Action { get; set; }


        [Column("state_id")]
        public int stateId { get; set; }

        [ForeignKey("stateId")]
        public State State { get; set; }

        public int Channel { get; set; }

    }
}
