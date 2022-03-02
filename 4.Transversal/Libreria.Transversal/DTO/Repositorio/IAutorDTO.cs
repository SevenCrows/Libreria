namespace Libreria.Transversal.DTO.Repositorio
{
    using System;
    public interface IAutorDTO
    {
        long Id { get; set; }
        int Identificacion { get; set; }
        string PrimerNombre { get; set; }
        string SegundoNombre { get; set; }
        string PrimerApellido { get; set; }
        string SegundoApellido { get; set; }
        DateTime FechaNacimiento { get; set; }
        string Ciudad { get; set; }
        string CorreoElectronico { get; set; }
    }
}
