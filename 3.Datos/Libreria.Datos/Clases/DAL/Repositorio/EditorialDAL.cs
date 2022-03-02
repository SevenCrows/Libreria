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
    public class EditorialDAL : ControlDatos<ContextoLibreria>, IEditorialAccion
    {
        internal DbContext contexto;

        public EditorialDAL()
        {
            this.contexto = this.ContextoBD;
        }

        public async Task<IEditorialDTO> AgregarEditorial(IEditorialDTO editorialDTO)
        {
            return await this.EjecutarTransaccionDAL<IEditorialDTO, EditorialDAL>(async () =>
            {
                Editorial entidad = Mapeador.MapearEntidadDTO(editorialDTO, new Editorial());
                await this.contexto.Set<Editorial>().AddAsync(entidad);
                contexto.SaveChanges();
                return entidad;
            });
        }

        public async Task<IEditorialDTO> EditarEditorial(IEditorialDTO editorialDTO)
        {
            return await this.EjecutarTransaccionDAL<IEditorialDTO, EditorialDAL>(async () =>
            {
                Editorial entidad = Mapeador.MapearEntidadDTO(editorialDTO, new Editorial());
                contexto.Entry(entidad).State = EntityState.Modified;
                contexto.SaveChanges();
                return entidad;
            });
        }

        public async Task<List<IEditorialDTO>> ConsultarListaEditorialPorFiltro(Expression<Func<IEditorialDTO, bool>> filtro)
        {
            return await this.EjecutarTransaccionDAL<List<IEditorialDTO>, EditorialDAL>(async () =>
            {
                return this.contexto.Set<Editorial>().Where(Mapeador.MapearExpresion<IEditorialDTO, Editorial>(filtro)).ToList<IEditorialDTO>();
            });
        }
    }
}
