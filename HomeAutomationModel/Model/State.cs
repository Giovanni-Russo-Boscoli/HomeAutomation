using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeAutomationModel.Model
{
    [Table("state")]
    public class State
    {
        [Key]
        [Column("state_id")]
        public int State_Id { get; set; }
        [Column("description")]
        public string Description { get; set; }

        [Column("type_id")]
        public int typeId { get; set; }

        [ForeignKey("typeId")]
        public TypeDevice TypeDevice { get; set; }
    }
}
