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
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} not found.");
            }
            _dbSet.Remove(entity);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = _dbSet.ToListAsync();

            return await entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                throw new Exception($"The entity with id : {id} is null/ not found");
            }
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity to update cannot be null.");
            }

            _dbSet.Update(entity);
        }
    }
}
