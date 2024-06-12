using Kinopoisk.Library.Entity;
using Kinopoisk.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.DAL.Interfaces
{
    internal interface IMovieRepository : IBaseRepository<MovieDTO>
    {
        Task<MovieDTO> GetByName(string name);
    }
}
