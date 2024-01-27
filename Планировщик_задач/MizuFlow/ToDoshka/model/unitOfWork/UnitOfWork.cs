// Паттерн Unit of Work помогает
// упростить работу с различными репозиториями и дает уверенность, что все репозитории будут использовать
// один и тот же DbContext.
//Так же использование шаблона Репозиторий и UoW позволяет создать правильную структуру для развертывания приложения
//и внедрения DI практик которые в том числе помогают в тестировании проекта:

using MizuFlow.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MizuFlow.Model
{
    public class UnitOfWork : IDisposable
    {
        private ToDoContext db = new ToDoContext();
        private ToDoRepository<User> usersRepository;
        private ToDoRepository<Tasks> tasksRepository;
        private ToDoRepository<Subtasks> subtasksRepository;
        private ToDoRepository<Task_Attachments> attachRepository;
        private ToDoRepository<Task_Group> groupRepository;


        public ToDoRepository<User> Users
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new ToDoRepository<User>(db);
                return usersRepository;
            }
        }

        public ToDoRepository<Tasks> Tasks
        {
            get
            {
                if (tasksRepository == null)
                    tasksRepository = new ToDoRepository<Tasks>(db);
                return tasksRepository;
            }
        }

        public ToDoRepository<Subtasks> Subtasks
        {
            get
            {
                if (subtasksRepository == null)
                    subtasksRepository = new ToDoRepository<Subtasks>(db);
                return subtasksRepository;
            }
        }

        public ToDoRepository<Task_Attachments> Attachments
        {
            get
            {
                if (attachRepository == null)
                    attachRepository = new ToDoRepository<Task_Attachments>(db);
                return attachRepository;
            }
        }
        public ToDoRepository<Task_Group> TaskGroup
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new ToDoRepository<Task_Group>(db);
                return groupRepository;
            }
        }

        public void Save()
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                }
            }
          
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
