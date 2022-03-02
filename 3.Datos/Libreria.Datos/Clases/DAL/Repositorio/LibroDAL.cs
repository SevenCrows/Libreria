namespace Libreria.Datos.Clases.DAL.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Libreria.Datos.Contexto;
    using Libreria.Datos.Repositorio;
    using Libreria.Transversal.Acciones.Repositorio;
    using Libreria.Transversal.DTO.Repositorio;
    using Libreria.Utilitario.Base;
    using Libreria.Utilitario.Control.BD;
    using Microsoft.EntityFrameworkCore;

    public class LibroDAL : ControlDatos<ContextoLibreria>, ILibroAccion
    {
        internal DbContext contexto;

        public LibroDAL()
        {
            this.contexto = this.ContextoBD;
        }

        public async Task<ILibroDTO> AgregarLibro(ILibroDTO libroDTO)
        {
            return await this.EjecutarTransaccionDAL<ILibroDTO, LibroDAL>(async () =>
            {
                Libro entidad = Mapeador.MapearEntidadDTO(libroDTO, new Libro());
                await this.contexto.Set<Libro>().AddAsync(entidad);
                contexto.SaveChanges();
                return entidad;
            });
        }

        public async Task<List<ILibroDTO>> ConsultarListaLibroPorFiltro(Expression<Func<ILibroDTO, bool>> filtro)
        {
            return await this.EjecutarTransaccionDAL<List<ILibroDTO>, LibroDAL>(async () =>
            {
                return this.contexto.Set<Libro>().Where(Mapeador.MapearExpresion<ILibroDTO, Libro>(filtro)).ToList<ILibroDTO>();
            });
        }
    }
}
