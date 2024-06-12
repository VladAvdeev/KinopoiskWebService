using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
