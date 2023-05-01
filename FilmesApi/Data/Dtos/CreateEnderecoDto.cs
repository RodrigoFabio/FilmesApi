using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateEnderecoDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Tamanho incorreto")]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }
    }
}
