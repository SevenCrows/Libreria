namespace Libreria.Api.Controller.Autor
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
    public class AutorController : ControlAPI
    {
        private readonly Lazy<IAutorNegocioAccion> negocioAutor;

        public AutorController()
        {
            this.negocioAutor = new Lazy<IAutorNegocioAccion>(() => new AutorBL());
        }

        [HttpPost]
        [Route("CrearAutor")]
        public async Task<Respuesta<IAutorDTO>> CrearAutor(Model.Autor autor)
        {
            return await this.EjecutarTransaccionAPI<Respuesta<IAutorDTO>, AutorController>(async () =>
            {                
                return await this.negocioAutor.Value.AgregarNuevoAutor(Mapeador.MapearObjetoPorJson<Model.Autor>(autor));
            });
        }
    }
}
