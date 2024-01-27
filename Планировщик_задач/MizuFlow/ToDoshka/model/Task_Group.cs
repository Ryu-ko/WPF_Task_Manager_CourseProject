using MizuFlow.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MizuFlow.model
{
    public class Task_Group
    {
        public Task_Group()
        {
            this.Tasks = new HashSet<Tasks>();
        }

        [Key]
        public int ID_Group { get; set; }

        [Required]
        [StringLength(50)]
        public string Group_Name { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }


    }
}
