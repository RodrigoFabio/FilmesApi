using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;


public class FilmeContext: DbContext
{
    //recebe as opcoes de acesso ao banco, ao contexto, e passa essas opcoes para a classe mae (DbContext)
    public FilmeContext(DbContextOptions<FilmeContext> opts) 
        : base(opts)
    { 
    
    }

    //cria uma propriedade que dará acesso ao conjunto de filmes,
    //é uma coleção de entidades Filme armazenadas no banco de dados. 
    public DbSet<Filme> Filmes { get; set; }

    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Endereco> Enderecos { get; set; }
}
