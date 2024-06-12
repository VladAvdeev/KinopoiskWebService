using Kinopoisk.DAL.Interfaces;
using Kinopoisk.Db;
using Kinopoisk.Library.Entity;
using Kinopoisk.Models.DTO;
using Kinopoisk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kinopoisk.DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _applicationContext;

        public MovieRepository(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Task<MovieDTO> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieDTO>> GetAll()
        {
            var movies = await _applicationContext.Movies.Include(t => t.Producer).Include(t => t.JenreToMovies).ThenInclude(t => t.Jenre)
                .Select(t => new MovieDTO
                {
                    MovieId = t.MovieId,
                    MovieName = t.MovieName,
                    Jenres = t.JenreToMovies.
                Select(t => new DictItem<int> { Id = t.IdJenre, Name = t.Jenre.JenreName }).ToList(),
                    Producer = new DictItem<int> { Id = t.ProducerId, Name = $"{t.Producer.FirstName} {t.Producer.LastName}" }
                }).ToListAsync();
            return movies;
        }

        public Task<MovieDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(MovieDTO entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(MovieDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
