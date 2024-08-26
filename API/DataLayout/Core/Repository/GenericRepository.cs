using DataLayout.Context;
using DataLayout.Core.IRepository;
using DataLayout.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Core.Repository
{
    // IRepository<T> arayüzünü implement eden, temel CRUD işlemlerini gerçekleştiren bir sınıf
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public AppDbContext context;
        public DbSet<T> dbSet;
        public ILogger logger;

        public GenericRepository(AppDbContext _context, ILogger _logger)
        {
            this.context = _context;
            this.logger = _logger;

            this.dbSet = context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.Where(filter).ToListAsync();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("GetAll Method error", typeof(T), ex);
                return Enumerable.Empty<T>();
            }
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                dbSet.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("Update Method error", typeof(T), ex);
                return false;
            }
        }
    }
}
