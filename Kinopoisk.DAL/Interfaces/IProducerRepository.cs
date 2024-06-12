using Kinopoisk.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.DAL.Interfaces
{
    public interface IProducerRepository : IBaseRepository<Producer>
    {
        Task<string> GetByName(string name);
        Task<string> GetByLastName(string lastName);
        Task<string> GetByFullName(string firstName, string lastName);
    }
}
