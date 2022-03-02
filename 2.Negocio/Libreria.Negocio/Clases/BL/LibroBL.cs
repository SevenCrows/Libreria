namespace Libreria.Negocio.Clases.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Libreria.Negocio.Recursos;
    using Libreria.Transversal.Acciones.Repositorio;
    using Libreria.Transversal.DTO.Repositorio;
    using Libreria.Utilitario.Base;
    using Libreria.Utilitario.Control.Negocio;

    public class LibroBL : ControlNegocio, ILibroNegocioAccion
    {
        private readonly Lazy<ILibroAccion> repositorioLibro;
        private readonly Lazy<IAutorAccion> repositorioAutor;
        private readonly Lazy<IEditorialAccion> repositorioEditorial;

        public LibroBL(Lazy<ILibroAccion> argRepositorioAccion = null,
            Lazy<IAutorAccion> argRepositorioAutorAccion = null,
            Lazy<IEditorialAccion> argRepositorioEditorialAccion = null)
        {
            this.repositorioLibro = argRepositorioAccion ?? new Lazy<ILibroAccion>();
            this.repositorioAutor = argRepositorioAutorAccion ?? new Lazy<IAutorAccion>();
            this.repositorioEditorial = argRepositorioEditorialAccion ?? new Lazy<IEditorialAccion>();
        }

        public async Task<Respuesta<ILibroDTO>> AgregarNuevoLibro(ILibroDTO libroDTO)
        {
            return await this.EjecutarTransaccionBL<Respuesta<ILibroDTO>, AutorBL>(System.Transactions.IsolationLevel.ReadUncommitted, async () =>
            {
                Respuesta<ILibroDTO> respuesta = new Respuesta<ILibroDTO>();
                try
                {
                    List<ILibroDTO> listaLibro = await this.ConsultarLibroPorCodigo(libroDTO);
                    if (listaLibro.Any())
                    {
                        respuesta.Mensajes = new List<string> { string.Format(rcsNegocio.MsgLibroExistente, libroDTO.Codigo) };
                        return respuesta;
                    }

                    List<IAutorDTO> listaAutor = await this.ConsultarAutorPorId(libroDTO);
                    if (!listaAutor.Any())
                    {
                        respuesta.Mensajes = new List<string> { rcsNegocio.MsgAutorNoExiste };
                        return respuesta;
                    }

                    List<IEditorialDTO> listaEditorial = await this.ConsultarEditorialPorId(libroDTO);
                    if (!listaEditorial.Any())
                    {
                        respuesta.Mensajes = new List<string> { rcsNegocio.MsgEditorialNoExiste };
                        return respuesta;
                    }

                    List<ILibroDTO> listaLibroEditorial = await this.ConsultarLibroPorEditorial(libroDTO);  
                    if (this.MaximoPermitidoEditorial(listaEditorial.FirstOrDefault(), listaLibroEditorial.Count()))
                    {
                        respuesta.Mensajes = new List<string> { rcsNegocio.MsgMaximoAlcanzado };
                        return respuesta;
                    }

                    ILibroDTO libro = await this.CrearLibro(libroDTO);
                    respuesta.Resultado = true;
                    respuesta.Mensajes = new List<string> { rcsNegocio.MsgCreacionExitosa };
                    respuesta.Entidades.Add(libro);
                    return respuesta;

                }
                catch (Exception)
                {
                    respuesta.Mensajes = new List<string> { rcsNegocio.MsgCreacionError };
                    return respuesta;
                }
            });
        }

        private Task<ILibroDTO> CrearLibro(ILibroDTO libroDTO)
        {
            return this.repositorioLibro.Value.AgregarLibro(libroDTO);
        }

        private Task<List<ILibroDTO>> ConsultarLibroPorCodigo(ILibroDTO libroDTO)
        {
            return this.repositorioLibro.Value.ConsultarListaLibroPorFiltro(x => x.Codigo == libroDTO.Codigo);
        }

        private Task<List<ILibroDTO>> ConsultarLibroPorEditorial(ILibroDTO libroDTO)
        {
            return this.repositorioLibro.Value.ConsultarListaLibroPorFiltro(x => x.EditorialId == libroDTO.EditorialId);
        }

        private Task<List<IAutorDTO>> ConsultarAutorPorId(ILibroDTO libroDTO)
        {
            return this.repositorioAutor.Value.ConsultarListaAutorPorFiltro(x => x.Id == libroDTO.AutorId);
        }

        private Task<List<IEditorialDTO>> ConsultarEditorialPorId(ILibroDTO libroDTO)
        {
            return this.repositorioEditorial.Value.ConsultarListaEditorialPorFiltro(x => x.Id == libroDTO.EditorialId);
        }

        private bool MaximoPermitidoEditorial(IEditorialDTO editorialDTO, long cantidadActual)
        {
            if (editorialDTO.RegistroMaximo == -1)
            {
                return false;
            }

            return (cantidadActual + 1) > editorialDTO.RegistroMaximo;
        }
    }
}
