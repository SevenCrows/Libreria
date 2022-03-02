namespace Libreria.Datos.Repositorio
{
    using System;
    public partial class Autor
    {
        public long Id { get; set; }
        public int Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Ciudad { get; set; }
        public string CorreoElectronico { get; set; }

        public virtual Libro Libro { get; set; }
    }
}