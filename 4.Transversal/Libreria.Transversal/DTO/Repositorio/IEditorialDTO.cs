namespace Libreria.Transversal.DTO.Repositorio
{
    public interface IEditorialDTO
    {
       long Id { get; set; }
       int Codigo { get; set; }
       string Nombre { get; set; }
       string Direccion { get; set; }
       int Telefono { get; set; }
       string CorreoElectronico { get; set; }
       long RegistroMaximo { get; set; }
    }
}
