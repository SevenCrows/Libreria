namespace Libreria.Datos.Repositorio
{
    public partial class Editorial
    {
        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public long RegistroMaximo { get; set; }

        public virtual Libro Libro { get; set; }
    }
}