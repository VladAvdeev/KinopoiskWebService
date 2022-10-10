using Kinopoisk.Db;
using Kinopoisk.Db.Entities;
using Kinopoisk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Kinopoisk.Controllers
{
    public class JenreController : ControllerBase
    {
        [HttpGet("jenre")]
        [ProducesResponseType(typeof(Jenre), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetJenres()
        {
            try
            {
                using MovieDbContext movieDbContext = new MovieDbContext();
                var jenreEntity = movieDbContext.Jenres.ToList();
                return Ok(jenreEntity);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }
        }

        [HttpPost("jenre")]
        [ProducesResponseType(typeof(Jenre), 200)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult AddJenre(Jenre jenre)
        {
            try
            {
                using MovieDbContext movieDbContext = new MovieDbContext();
                movieDbContext.Jenres.Add(new Jenre
                {
                    JenreName = jenre.JenreName,

                });
                movieDbContext.SaveChanges();
                return Ok(jenre);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseModel(228, "Сервер дал сбой"));
            }

        }
    }
}
