using Kinopoisk.Db;
using Kinopoisk.Db.Entities;
using Kinopoisk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Kinopoisk.Controllers
{
    [Route("api")]
    public class UserController : ControllerBase
    {
        [HttpGet("users")]
        public IEnumerable<User> GetUsers()
        {
            using MovieDbContext dbContext = new MovieDbContext();
            var test = dbContext.Users.OrderBy(x=>x.Id).ToList();
            return test;
        }
        [HttpPost("users")]
        public User AddUser([FromBody]User user)//dto
        {
            using MovieDbContext movieDbContext = new MovieDbContext();
            var userEntity = new User
            {
                Name = user.Name,
                Age = user.Age,
            };
            movieDbContext.Users.Add(userEntity);
            movieDbContext.SaveChanges();
            return userEntity;

        }
        [HttpPut("users/{id}")]
        public User UpdateUser([FromRoute]int id,[FromBody]User user)
        {
            using MovieDbContext movieDbContext = new MovieDbContext();
            var userEntity = movieDbContext.Users.FirstOrDefault(x => x.Id == id);
            userEntity.Name = user.Name;
            userEntity.Age = user.Age;
            //var oldUser = movieDbContext.Users.Where(x => x.Id == user.Id).Single<User>();
            //oldUser.Id = user.Id;
            //oldUser.Name = user.Name;
            //oldUser.Age = user.Age;
            movieDbContext.SaveChanges();
            return userEntity;

        }

        [HttpPut("users2/{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateUser2([FromRoute] int id, [FromBody] User user)
        {
            try
            {
                using MovieDbContext movieDbContext = new MovieDbContext();
                var userEntity = movieDbContext.Users.FirstOrDefault(x => x.Id == id);
                if (userEntity == null)
                    return NotFound();
                if (user == null || user.Name == null || user.Age == 0)
                    return BadRequest();
                userEntity.Name = user.Name;
                userEntity.Age = user.Age;
                //var oldUser = movieDbContext.Users.Where(x => x.Id == user.Id).Single<User>();
                //oldUser.Id = user.Id;
                //oldUser.Name = user.Name;
                //oldUser.Age = user.Age;
                movieDbContext.SaveChanges();
                return Ok(userEntity);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой") );
            }
            

        }
        
        [HttpDelete("users/{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteUser([FromRoute]int id)
        {
            try
            {
                using MovieDbContext movieDbContext = new MovieDbContext();
                var userEntity = movieDbContext.Users.FirstOrDefault(x => x.Id == id);
                if(userEntity == null)
                {
                    return NotFound();
                }
                movieDbContext.Users.Remove(userEntity);
                movieDbContext.SaveChanges();
                return Ok(userEntity);

            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }
            
        }

    }
}
