using System.ComponentModel.DataAnnotations;


namespace FilmesApi.Data.Dtos;

public class UpdateFilmeDto
{

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(50, ErrorMessage = "Tamanho do título não é aceitável")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [StringLength(50, ErrorMessage = "Tamanho do genero não é aceitável")]
    public string Genero { get; set; }

    [Required]
    [Range(70, 500, ErrorMessage = "A duração precisa ter entre 70 e 500 minutos")]
    public int Duracao { get; set; }
}
