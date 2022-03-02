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

    public class AutorDAL : ControlDatos<ContextoLibreria>, IAutorAccion
    {
        internal DbContext contexto;

        public AutorDAL()
        {
            this.contexto = this.ContextoBD;
        }

        public async Task<IAutorDTO> AgregarAutor(IAutorDTO AutorDTO)
        {
            return await this.EjecutarTransaccionDAL<IAutorDTO, AutorDAL>(async () =>
            {
                Autor entidad = Mapeador.MapearEntidadDTO(AutorDTO, new Autor());
                await this.contexto.Set<Autor>().AddAsync(entidad);
                contexto.SaveChanges();
                return entidad;
            });
        }

        public async Task<List<IAutorDTO>> ConsultarListaAutorPorFiltro(Expression<Func<IAutorDTO, bool>> filtro)
        {
            return await this.EjecutarTransaccionDAL<List<IAutorDTO>, AutorDAL>(async () =>
            {
                return this.contexto.Set<Autor>().Where(Mapeador.MapearExpresion<IAutorDTO, Autor>(filtro)).ToList<IAutorDTO>();
            });
        }
    }
}
