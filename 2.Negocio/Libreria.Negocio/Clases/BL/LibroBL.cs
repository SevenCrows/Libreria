namespace Libreria.Negocio.Clases.BL
{
    using System;
    using System.Threading.Tasks;
    using Libreria.Transversal.Acciones.Repositorio;
    using Libreria.Transversal.DTO.Repositorio;
    using Libreria.Utilitario.Base;
    using Libreria.Utilitario.Negocio;

    public class LibroBL : ControlNegocio, ILibroNegocioAccion
    {
        private readonly Lazy<ILibroAccion> repositorioLibro;

        public LibroBL(Lazy<ILibroAccion> argRepositorioAccion = null)
        {
            this.repositorioLibro = argRepositorioAccion ?? new Lazy<ILibroAccion>();
        }

        public Task<Respuesta<ILibroDTO>> AgregarNuevoLibro(ILibroDTO editorialDTO)
        {
            throw new NotImplementedException();
        }
    }
}
