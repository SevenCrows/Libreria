namespace Libreria.Api.Model
{
    using System.ComponentModel.DataAnnotations;
    using Libreria.Transversal.DTO.Repositorio;
    public class Editorial : IEditorialDTO
    {
        public long Id { get; set; }

        [Required]
        [Range(1, 99999999)]
        public int Codigo { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Direccion { get; set; }

        [Required]
        [Range(1, 99999999)]
        public int Telefono { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        [Required]
        [Range(1, 99999999)]
        public long RegistroMaximo { get; set; }
    }
}
