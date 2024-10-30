using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByID(int id);   
        Task<bool> Delete(T entity);
        Task<bool> Delete(int id);
        Task<bool> Create(T entity);
        Task<T> Update(T entity);
        IQueryable<T> GetAll();
    }
}
