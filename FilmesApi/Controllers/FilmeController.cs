using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FilmeController : ControllerBase
    {

        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaPorId), new {id = filme.Id}, filme); 
        }

       // [HttpGet]
      //  public IEnumerable<Filme> RecuperaFilmes()
      //  {
      //      return filmes;
      //  }

       [HttpGet("{Id}")]
        public IActionResult RecuperaPorId( int Id)
       {
           var filme = filmes.FirstOrDefault(f => f.Id == Id);
            if (filme == null) return NotFound();
            return Ok(filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaPorQuantidade([FromQuery]int skip =0, [FromQuery] int take=50)
        {
            return filmes.Skip(skip).Take(take);
        }

    }
}
