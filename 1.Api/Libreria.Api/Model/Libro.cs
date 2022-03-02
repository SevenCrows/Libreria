namespace Libreria.Api.Model
{
    using Libreria.Transversal.DTO.Repositorio;

    public class Libro : ILibroDTO
    {
        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Paginas { get; set; }
        public int Anio { get; set; }
        public long EditorialId { get; set; }
        public long AutorId { get; set; }
    }
}
