namespace Libreria.Transversal.Acciones.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Libreria.Transversal.DTO.Repositorio;

    public interface IAutorAccion
    {
        Task<IAutorDTO> AgregarAutor(IAutorDTO AutorlDTO);
        Task<List<IAutorDTO>> ConsultarListaAutorPorFiltro(Expression<Func<IAutorDTO, bool>> filtro);
    }

    public interface IAutorNegocioAccion
    {

    }
}
