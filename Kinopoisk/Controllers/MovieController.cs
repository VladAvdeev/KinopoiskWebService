using Kinopoisk.Db;
using Kinopoisk.Db.Entities;
using Kinopoisk.Models;
using Kinopoisk.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace Kinopoisk.Controllers
{
    
    public class MovieController : ControllerBase
    {
        [HttpGet("movies")]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetMovies()
        {
            try
            {

            using MovieDbContext movieDbContext = new MovieDbContext();
            var movies = movieDbContext.Movies.Include(t => t.Producer).Include(t => t.JenreToMovies).ThenInclude(t => t.Jenre)
                .Select(t => new MovieDTO
                {
                    MovieId = t.MovieId,
                    MovieName = t.MovieName,
                    Jenres = t.JenreToMovies.
                Select(t => new DictItem<int> { Id = t.IdJenre, Name = t.Jenre.JenreName }).ToList(),
                    Producer = new DictItem<int> { Id = t.ProducerId, Name = $"{t.Producer.FirstName} {t.Producer.LastName}" }
                }).ToList();
            return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }
        }
        //[HttpGet("users2")]
        //public IEnumerable<User> GetMovies2()
        //{
        //    using MovieDbContext movieDbContext2 = new MovieDbContext();
        //    return movieDbContext2.Users.ToList();
        //}
        [HttpPost("movies")]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult AddMovie([FromBody]MovieDTO movie)
        {
            try
            {

            using MovieDbContext movieDbContext = new MovieDbContext();
            movieDbContext.Movies.Add(new Movie
            {
                
                MovieName=movie.MovieName,
                CreateYear = movie.CreateYear,
                Country = movie.Country,
                ProducerId = movie.ProducerId, //для существующего продюссера
                //Producer = new Producer {FirstName = movie.Producer.Name, LastName = "test", BirthDay = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)), Country = "qwe" }, //для создания нового
                //JenreToMovies = movie.Jenres.Select(t => new JenreToMovie {IdJenre = t.Id, Jenre = new Jenre {JenreId = t.Id, JenreName = t.Name } }).ToList() // Добавление новых жанров в таблицу и привязка жанров к фильму
                JenreToMovies = movie.Jenres.Select(t => new JenreToMovie { IdJenre = t.Id}).ToList() //Привязка существующих жанров к фильму
            });
                movieDbContext.SaveChanges();
                return Ok(movie);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }
        }
        [HttpPut("movies")]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateMovie([FromRoute]int id,[FromBody]MovieDTO movie)
        {
            try
            {
                using MovieDbContext movieDbContext= new MovieDbContext();
                var movieEntity = movieDbContext.Movies.FirstOrDefault(t => t.MovieId == id);
                if (movieEntity == null)
                    return NotFound();
                if (movie == null || movie.MovieName == null)
                    return BadRequest();
                movieEntity.MovieName = movie.MovieName;
                movieEntity.CreateYear = movie.CreateYear;
                movieEntity.Country = movie.Country;
                movieEntity.ProducerId = movie.ProducerId;
                movieDbContext.SaveChanges();
                return Ok(movieEntity);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }
        }
        [HttpDelete("movies")]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteMovie([FromRoute]int id)
        {
            try
            {
            using MovieDbContext movieDbContext = new MovieDbContext();
            var movieEntity = movieDbContext.Movies.FirstOrDefault(t => t.MovieId == id);
            movieDbContext.Movies.Remove(movieEntity);
            movieDbContext.SaveChanges();
            return Ok(movieEntity);

            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }
        }
    }
}
