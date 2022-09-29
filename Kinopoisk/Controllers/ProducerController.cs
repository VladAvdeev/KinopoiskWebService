using Kinopoisk.Db;
using Kinopoisk.Db.Entities;
using Kinopoisk.Models;
using Kinopoisk.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kinopoisk.Controllers
{
    [Route("api")]
    public class ProducerController : ControllerBase
    {
       
        [HttpGet("producers")]
        [ProducesResponseType(typeof(Producer), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetProducesr()
        {
            try
            {

            using MovieDbContext movieDbContext = new MovieDbContext();
            //var producers2 = movieDbContext.Producers.Include(t=>t.Movies).ToList();
            var producers = movieDbContext.Producers.Include(t => t.Movies)
                .Select(t => new ProducerDTO
                {
                    Id = t.ProducerId,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    MovieList = t.Movies.Select(x => new DictItem<int> { Id = x.MovieId, Name = x.MovieName } ).ToList()
                }).ToArray();
            return Ok(producers);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }
        }
        //проверить
        [HttpPost("producer")]
        [ProducesResponseType(typeof(Producer), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult AddProducer([FromBody]ProducerDTO producer)
        {
            try
            {
            using MovieDbContext movieDbContext = new MovieDbContext();
                movieDbContext.Producers.Add(new Producer
                {
                    ProducerId = producer.Id,
                    FirstName = producer.FirstName,
                    LastName = producer.LastName,
                    BirthDay = producer.BirthDay,
                    Country = producer.Country,
                    // producer.MovieList.Select(t => new JenreToMovie { IdMovie = t.Id, Movie = new Movie { MovieName = t.Name } }).ToList()
                    Movies = producer.MovieList.Select(t => new Movie { MovieId = t.Id, MovieName = t.Name }).ToList()
                });
            movieDbContext.SaveChanges();
            return Ok(producer);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }
        }
        [HttpPost("producer")]
        [ProducesResponseType(typeof(Producer), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateProducer([FromRoute]int id, [FromBody]Producer producer)
        {
            try
            {
                using MovieDbContext movieDbContext = new MovieDbContext();
                var producerEntity = movieDbContext.Producers.FirstOrDefault(t => t.ProducerId == id);
                if (producerEntity == null)
                    return NotFound();
                if (producer.FirstName == null || producer.LastName == null)
                    return BadRequest();
                producerEntity.FirstName = producer.FirstName;
                producerEntity.LastName = producer.LastName;
                producerEntity.BirthDay = producer.BirthDay;
                producerEntity.Country = producer.Country;
                return Ok(producerEntity);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }
        }
        [HttpDelete("producer")]
        [ProducesResponseType(typeof(Producer), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteProducer([FromRoute]int id)
        {
            try
            {
                using MovieDbContext movieDbContext=new MovieDbContext();
                var producerEntity = movieDbContext.Producers.FirstOrDefault(t => t.ProducerId == id);
                if (producerEntity == null)
                    return NotFound();
                movieDbContext.Producers.Remove(producerEntity);
                return Ok(producerEntity);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }
        }
    }
}
