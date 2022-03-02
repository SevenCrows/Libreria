namespace Libreria.Api.Model
{
    using System.ComponentModel.DataAnnotations;
    using Libreria.Transversal.DTO.Repositorio;

    public class Libro : ILibroDTO
    {
        public long Id { get; set; }

        [Required]
        [Range(1, 99999999)]
        public int Codigo { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Genero { get; set; }

        [Required]
        [Range(1, 2000)]
        public int Paginas { get; set; }

        [Required]
        [Range(1, 9999)]
        public int Anio { get; set; }

        [Required]
        [Range(1, 99999999)]
        public long EditorialId { get; set; }

        [Required]
        [Range(1, 99999999)]
        public long AutorId { get; set; }
    }
}
