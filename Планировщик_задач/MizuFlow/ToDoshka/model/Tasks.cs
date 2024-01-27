using MizuFlow.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MizuFlow.Model
{
    public class Tasks
    {
        public Tasks()
        {
            Attachments = new HashSet<Task_Attachments>();
            Subtasks = new HashSet<Subtasks>();
        }

        [Key]
        public int ID_Task { get; set; }
        
        [Required]
        public int Task_UserID { get; set; }
       
        [Required]
        public string Task_Name { get; set; }
       
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime?CreationDateTime { get; set; }
        
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime?Deadline { get; set; } 
        
        public int? Priority { get; set; } 
        
        public bool? isWork { get; set; }
        
        public bool? isCheck { get; set; }
        
        [Column(TypeName = "smalldatetime")]
        public DateTime? CheckTime { get; set; }
         
        public int? Task_ID_Group { get; set; } 

        public virtual ICollection<Task_Attachments> Attachments { get; set; }
        public virtual ICollection<Subtasks> Subtasks { get; set; }

        public virtual User Users { get; set; }
        public virtual Task_Group Groups { get; set; } 

    }
}
