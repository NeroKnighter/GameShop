using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShop;
using GameShop.DAL;


namespace Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDBContext _context;
        private DbSet<T> _dbSet;
        public BaseRepository(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<bool> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
            
        public async Task<bool> Delete(T entity)
        {
            
            _dbSet.Remove(entity); 
            await _context.SaveChangesAsync(); 
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public async Task<T> GetByID(int id)
        {
            return _dbSet.Find(id);  
        }
            
        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity); 
            await _context.SaveChangesAsync();
            return entity;  
        }
    }
}
