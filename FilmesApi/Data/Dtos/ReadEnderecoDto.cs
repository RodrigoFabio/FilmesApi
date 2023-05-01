using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class ReadEnderecoDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Tamanho incorreto")]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }
    }
}
