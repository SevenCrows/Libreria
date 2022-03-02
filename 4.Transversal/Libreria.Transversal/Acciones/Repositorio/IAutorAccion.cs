namespace Libreria.Transversal.Acciones.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Libreria.Transversal.DTO.Repositorio;
    using Libreria.Utilitario.Base;

    public interface IAutorAccion
    {
        Task<IAutorDTO> AgregarAutor(IAutorDTO autorDTO);
        Task<List<IAutorDTO>> ConsultarListaAutorPorFiltro(Expression<Func<IAutorDTO, bool>> filtro);
    }

    public interface IAutorNegocioAccion
    {
        Task<Respuesta<IAutorDTO>> AgregarNuevoAutor(IAutorDTO autorDTO);
    }
}
