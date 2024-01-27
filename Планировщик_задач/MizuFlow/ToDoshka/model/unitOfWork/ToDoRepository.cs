using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace MizuFlow.Model
{

    //Одним из наиболее часто используемых паттернов при работе с данными является паттерн 'Репозиторий'.
    //    Репозиторий позволяет абстрагироваться от конкретных подключений к источникам данных, с которыми работает программа,
    //    и является промежуточным звеном между классами, непосредственно взаимодействующими с данными, и остальной программой.
    public class ToDoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ToDoContext _context;
        DbSet<TEntity> _dbSet;

        public ToDoRepository(ToDoContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            try
            {
                _dbSet.Add(item);
            }
            catch (Exception ex)
            {
                // Обработайте исключение или выведите информацию о нем для отладки.
                Console.WriteLine(ex.Message);
            }
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
