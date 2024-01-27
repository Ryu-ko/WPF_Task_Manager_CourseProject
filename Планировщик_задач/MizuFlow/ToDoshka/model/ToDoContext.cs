using MizuFlow.model;
using System.Data.Entity;
using System.Windows;

namespace MizuFlow.Model
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
            : base("name=MizuFlow")
        {
           

        }

        public DbSet<Task_Attachments> attachments { get; set; }
        public DbSet<Subtasks> subtasks { get; set; }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Task_Group> groups { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subtasks>()
                .HasMany(e => e.Attachments)
                .WithOptional(e => e.Subtasks)
                .HasForeignKey(e => e.TA_SubtaskID);

            modelBuilder.Entity<Tasks>()
                .HasMany(e => e.Attachments)
                .WithOptional(e => e.Tasks)
                .HasForeignKey(e => e.TA_TaskID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Attachments)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.TA_UserID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.Task_UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task_Group>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.Groups)
                .HasForeignKey(e => e.Task_ID_Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tasks>()
                 .HasMany(e => e.Subtasks)
                 .WithOptional(e => e.Tasks)
                 .HasForeignKey(e => e.TaskID)
                 .WillCascadeOnDelete(true);

        }
    }
}
