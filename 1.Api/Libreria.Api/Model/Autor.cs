namespace Libreria.Api.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Libreria.Transversal.DTO.Repositorio;
    public class Autor : IAutorDTO
    {
        public long Id { get; set; }

        [Required]
        [Range(1, 99999999)]
        public int Identificacion { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 4)]
        public string PrimerNombre { get; set; }

        [StringLength(250)]
        public string SegundoNombre { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 4)]
        public string PrimerApellido { get; set; }

        [StringLength(250)]
        public string SegundoApellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 4)]
        public string Ciudad { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string CorreoElectronico { get; set; }
    }
}
