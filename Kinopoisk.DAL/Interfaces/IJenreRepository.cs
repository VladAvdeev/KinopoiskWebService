using Kinopoisk.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.DAL.Interfaces
{
    public interface IJenreRepository : IBaseRepository<Jenre>
    {
        Task<Jenre> GetByJenre(string name);
    }
}
