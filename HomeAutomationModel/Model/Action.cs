using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeAutomationModel.Model
{
    [Table("action")]
    public class Action
    {
        [Key]
        [Column("action_id")]
        public int Action_Id { get; set; }
        [Column("description")]
        public string Description { get; set; }

        [Column("type_id")]
        public int typeId { get; set; }

        [ForeignKey("typeId")]
        public TypeDevice TypeDevice { get; set; }
    }
}
