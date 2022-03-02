namespace Libreria.Api.Model
{
    using System;
    using Libreria.Transversal.DTO.Repositorio;
    public class Autor : IAutorDTO
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
    }
}
