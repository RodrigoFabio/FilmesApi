using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        //recebe um contexto e atribui a variavel _context da nossa classe
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges(); 
        return CreatedAtAction(nameof(RecuperaPorId), new {id = filme.Id}, filme); 
    }

   // [HttpGet]
  //  public IEnumerable<Filme> RecuperaFilmes()
  //  {
  //      return filmes;
  //  }

   [HttpGet("{Id}")]
    public IActionResult RecuperaFilmePorId( int Id)
   {    
       var filme = _context.Filmes.FirstOrDefault(f => f.Id == Id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery] int take = 50)
    {
        //"https://localhost7929/filme?skip=10&take=100"
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);   
        _context.SaveChanges();
        return NoContent(); 
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto>patch) 
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        //converte o filme encontrado no banco para um tipo filmeDto
        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        //tenta aplicar a correção trazida no patch ao filmeDto banco
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(ModelState))
        {
            return ValidationProblem();
        }

        //converte de volta para o tipo filme e salva no banco
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Remove(filme); 
        _context.SaveChanges();
        return NoContent(); 
    }
}
