namespace Libreria.Negocio.Clases.BL
{
    using System;
    using System.Threading.Tasks;
    using Libreria.Transversal.Acciones.Repositorio;
    using Libreria.Transversal.DTO.Repositorio;
    using Libreria.Utilitario.Base;
    using Libreria.Utilitario.Negocio;

    public class EditorialBL: ControlNegocio, IEditorialNegocioAccion
    {
        private readonly Lazy<IEditorialAccion> repositorioEditorial;

        public EditorialBL(Lazy<IEditorialAccion> argRepositorioAccion = null)
        {
            this.repositorioEditorial = argRepositorioAccion ?? new Lazy<IEditorialAccion>();
        }

        public Task<Respuesta<IEditorialDTO>> AgregarNuevoEditorial(IEditorialDTO editorialDTO)
        {
            throw new NotImplementedException();
        }
    }
}
