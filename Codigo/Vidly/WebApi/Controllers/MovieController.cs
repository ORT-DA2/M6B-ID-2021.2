
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFristWebApi.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        public MovieController() { }

        //GET localhost:5001/movies?stars=2
        [HttpGet]
        public IActionResult GetMoviesFiltered(int stars)
        {
            return Ok();
        }

        //GET localhost:5001/movies/2 -> GetMovie
        [HttpGet("{movieId}", Name = "GetMovie")]
        public IActionResult GetOneMovie(int movieId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            return CreatedAtRoute("GetMovie", new { movieId = 2 }, movie);
        }

        //PUT localhost:5001/movies/2
        [HttpPut("{movieId}")]
        public IActionResult UpdateMovie(int movieId, object movie)
        {
            return NoContent();
        }

        //DELETE localhost:5001/movies/2
        [HttpDelete("{movieId}")]
        public IActionResult DeleteOneMovie(int movieId)
        {
            return NoContent();
        }

        //DELETE localhost:5001/movies
        [HttpDelete]
        public IActionResult DeleteAllMovies()
        {
            return NoContent();
        }
    }
}