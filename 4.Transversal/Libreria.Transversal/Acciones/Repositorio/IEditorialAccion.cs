namespace Libreria.Transversal.Acciones.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Libreria.Transversal.DTO.Repositorio;

    public interface IEditorialAccion
    {
        Task<IEditorialDTO> AgregarEditorial(IEditorialDTO editorialDTO);
        Task<List<IEditorialDTO>> ConsultarListaEditorialPorFiltro(Expression<Func<IEditorialDTO, bool>> filtro);
    }

    public interface IEditorialNegocioAccion
    {

    }
}
