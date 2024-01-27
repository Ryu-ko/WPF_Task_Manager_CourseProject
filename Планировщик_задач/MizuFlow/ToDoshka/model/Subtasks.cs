using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MizuFlow.Model
{
    public class Subtasks
    {
        public Subtasks()
        {
            this.Attachments = new HashSet<Task_Attachments>();
        }

        [Key]
        public int ID_Subtask { get; set; }

        public int? TaskID { get; set; }

        [Required]
        public string Subtask_Name { get; set; }

        public bool? isCheck { get; set; }

        public virtual ICollection<Task_Attachments> Attachments { get; set; }

        
        public virtual Tasks Tasks { get; set; }
    }
}
