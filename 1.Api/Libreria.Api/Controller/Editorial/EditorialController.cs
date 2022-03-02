namespace Libreria.Api.Controller.Editorial
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
    public class EditorialController : ControlAPI
    {
        private readonly Lazy<IEditorialNegocioAccion> negocioEditorial;

        public EditorialController()
        {
            this.negocioEditorial = new Lazy<IEditorialNegocioAccion>(() => new EditorialBL());
        }

        [HttpPost]
        [Route("CrearEditorial")]
        public async Task<Respuesta<IEditorialDTO>> CrearEditorial(Model.Editorial editorial)
        {
            return await this.EjecutarTransaccionAPI<Respuesta<IEditorialDTO>, EditorialController>(async () =>
            {
                return await this.negocioEditorial.Value.AgregarNuevoEditorial(Mapeador.MapearObjetoPorJson<Model.Editorial>(editorial));
            });
        }
    }
}
