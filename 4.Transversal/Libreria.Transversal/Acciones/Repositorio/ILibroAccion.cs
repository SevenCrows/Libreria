namespace Libreria.Transversal.Acciones.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Libreria.Transversal.DTO.Repositorio;
    using Libreria.Utilitario.Base;

    public interface ILibroAccion
    {
        Task<ILibroDTO> AgregarLibro(ILibroDTO libroDTO);
        Task<List<ILibroDTO>> ConsultarListaLibroPorFiltro(Expression<Func<ILibroDTO, bool>> filtro);
    }

    public interface ILibroNegocioAccion
    {
        Task<Respuesta<ILibroDTO>> AgregarNuevoLibro(ILibroDTO editorialDTO);
    }
}
