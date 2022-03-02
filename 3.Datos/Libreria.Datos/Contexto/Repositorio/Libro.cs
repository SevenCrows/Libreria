namespace Libreria.Datos.Repositorio
{
    public partial class Libro
    {
        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Paginas { get; set; }
        public int Anio { get; set; }
        public long EditorialId { get; set; }
        public long AutorId { get; set; }

        public virtual Editorial Id1 { get; set; }
        public virtual Autor IdNavigation { get; set; }
    }
}