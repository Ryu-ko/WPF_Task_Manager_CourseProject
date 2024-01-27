using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MizuFlow.Model
{
    public class User
    {
        public User()
        {
            this.Attachments = new HashSet<Task_Attachments>();
            this.Tasks = new HashSet<Tasks>();
        }

        [Key]
        public int ID_User { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(40)]
        public string User_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string User_Surname { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
        public virtual ICollection<Task_Attachments> Attachments { get; set; }

       
    }
}
