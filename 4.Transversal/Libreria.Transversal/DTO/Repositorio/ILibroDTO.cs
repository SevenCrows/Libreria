namespace Libreria.Transversal.DTO.Repositorio
{
    public interface ILibroDTO
    {
        long Id { get; set; }
        int Codigo { get; set; }
        string Titulo { get; set; }
        string Genero { get; set; }
        int Paginas { get; set; }
        int Anio { get; set; }
        long EditorialId { get; set; }
        long AutorId { get; set; }
    }
}
