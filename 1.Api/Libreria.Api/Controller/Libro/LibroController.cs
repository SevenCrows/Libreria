namespace Libreria.Api.Controller.Libro
{
    using System;
    using System.Threading.Tasks;
    using Libreria.Negocio.Clases.BL;
    using Libreria.Transversal.Acciones.Repositorio;
    using Libreria.Transversal.DTO.Repositorio;
    using Libreria.Utilitario.Base;
    using Libreria.Utilitario.Control.API;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControlAPI
    {
        private readonly Lazy<ILibroNegocioAccion> negocioLibro;

        public LibroController()
        {
            this.negocioLibro = new Lazy<ILibroNegocioAccion>(() => new LibroBL());
        }

        [HttpPost]
        [Route("CrearLibro")]
        public async Task<Respuesta<ILibroDTO>> CrearLibro(Model.Libro Libro)
        {
            return await this.EjecutarTransaccionAPI<Respuesta<ILibroDTO>, LibroController>(async () =>
            {
                return await this.negocioLibro.Value.AgregarNuevoLibro(Mapeador.MapearObjetoPorJson<Model.Libro>(Libro));
            });
        }
    }
}
