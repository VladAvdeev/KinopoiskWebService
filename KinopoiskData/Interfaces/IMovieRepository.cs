using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskData.Interfaces
{
    public interface IMovieRepository : IBaseRepository<MovieDTO>
    {
        Task<MovieDTO> GetMovieByName(string name);
    }
}
