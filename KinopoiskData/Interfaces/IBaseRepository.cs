using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskData.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<bool> Create(T entity);
        Task<T> GetById(int id);
        Task<bool> Delete(T entity);
        Task<T> Update(T entity);
    }
}
