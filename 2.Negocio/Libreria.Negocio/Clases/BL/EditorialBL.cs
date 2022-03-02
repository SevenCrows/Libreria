namespace Libreria.Negocio.Clases.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Libreria.Datos.Clases.DAL.Repositorio;
    using Libreria.Negocio.Recursos;
    using Libreria.Transversal.Acciones.Repositorio;
    using Libreria.Transversal.DTO.Repositorio;
    using Libreria.Utilitario.Base;
    using Libreria.Utilitario.Control.Negocio;

    public class EditorialBL: ControlNegocio, IEditorialNegocioAccion
    {
        private readonly Lazy<IEditorialAccion> repositorioEditorial;

        public EditorialBL(Lazy<IEditorialAccion> argRepositorioAccion = null)
        {
            this.repositorioEditorial = argRepositorioAccion ?? new Lazy<IEditorialAccion>(() => new EditorialDAL());
        }

        public async Task<Respuesta<IEditorialDTO>> AgregarNuevoEditorial(IEditorialDTO editorialDTO)
        {
            return await this.EjecutarTransaccionBL<Respuesta<IEditorialDTO>, EditorialBL>(System.Transactions.IsolationLevel.ReadUncommitted, async () =>
            {
                Respuesta<IEditorialDTO> respuesta = new Respuesta<IEditorialDTO>();
                try
                {
                    List<IEditorialDTO> listaEditorial = await this.ConsultarEditorialPorCodigo(editorialDTO);

                    if (listaEditorial.Any())
                    {
                        respuesta.Mensajes = new List<string> { string.Format(rcsNegocio.MsgEditorialExistente, editorialDTO.Codigo) };
                        return respuesta;
                    }

                    IEditorialDTO editorial = await this.CrearEditorial(editorialDTO);
                    respuesta.Resultado = true;
                    respuesta.Mensajes = new List<string> { rcsNegocio.MsgCreacionExitosa };
                    respuesta.Entidades.Add(editorial);
                    return respuesta;

                }
                catch (Exception)
                {
                    respuesta.Mensajes = new List<string> { rcsNegocio.MsgCreacionError };
                    return respuesta;
                }
            });
        }

        private Task<IEditorialDTO> CrearEditorial(IEditorialDTO editorialDTO)
        {
            return this.repositorioEditorial.Value.AgregarEditorial(editorialDTO);
        }

        private Task<List<IEditorialDTO>> ConsultarEditorialPorCodigo(IEditorialDTO editorialDTO)
        {
            return this.repositorioEditorial.Value.ConsultarListaEditorialPorFiltro(x => x.Codigo == editorialDTO.Codigo);
        }
    }
}
