using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MizuFlow.Model
{
    public class Task_Attachments
    {
        [Key]
        public int ID_Task_Attachments { get; set; }

        public int? TA_UserID { get; set; }
        public int? TA_TaskID { get; set; }

        public int? TA_SubtaskID { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        public byte[] Image { get; set; }

        [StringLength(100)]
        public string FilePath { get; set; }

        public byte[] File { get; set; }


        public virtual Subtasks Subtasks { get; set; }
        public virtual Tasks Tasks { get; set; }
        public virtual User User { get; set; }
    }
}
