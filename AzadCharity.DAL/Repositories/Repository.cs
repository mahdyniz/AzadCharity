using AzadCharity.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzadCharity.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CharityContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(CharityContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} not found.");
            }
            _dbSet.Remove(entity);

        }

        public IEnumerable<T> GetAll()
        {
            var entities = _dbSet.ToList();

            return entities;
        }

        public T GetById(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
            {
                throw new Exception($"The entity with id : {id} is null/ not found");
            }
            return entity;
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity to update cannot be null.");
            }

            _dbSet.Update(entity);
        }
    }
}
