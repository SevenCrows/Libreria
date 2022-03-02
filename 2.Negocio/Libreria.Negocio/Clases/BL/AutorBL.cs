namespace Libreria.Negocio.Clases.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Libreria.Negocio.Clases.BO;
    using Libreria.Negocio.Recursos;
    using Libreria.Transversal.Acciones.Repositorio;
    using Libreria.Transversal.DTO.Repositorio;
    using Libreria.Utilitario.Base;
    using Libreria.Utilitario.Control.Negocio;

    public class AutorBL : ControlNegocio, IAutorNegocioAccion
    {
        private readonly Lazy<IAutorAccion> repositorioAutor;

        public AutorBL(Lazy<IAutorAccion> argRepositorioAccion = null)
        {
            this.repositorioAutor = argRepositorioAccion ?? new Lazy<IAutorAccion>();
        }

        public async Task<Respuesta<IAutorDTO>> AgregarNuevoAutor(IAutorDTO autorDTO)
        {
            return await this.EjecutarTransaccionBL<Respuesta<IAutorDTO>, AutorBL>(System.Transactions.IsolationLevel.ReadUncommitted, async () =>
            {
                Respuesta<IAutorDTO> respuesta = new Respuesta<IAutorDTO>();
                try
                {
                    List<IAutorDTO> listaAutor = await this.ConsultarAutorPorIdentificacion(autorDTO);

                    if (listaAutor.Any())
                    {
                        respuesta.Mensajes = new List<string> { string.Format(rcsNegocio.MsgAutorExistente, autorDTO.Identificacion)};
                        return respuesta;
                    }

                    IAutorDTO autor = await this.CrearAutor(autorDTO);
                    respuesta.Resultado = true;
                    respuesta.Mensajes = new List<string> { rcsNegocio.MsgCreacionExitosa };
                    respuesta.Entidades.Add(autor);
                    return respuesta;

                }
                catch (Exception)
                {
                    respuesta.Mensajes = new List<string> { rcsNegocio.MsgCreacionError };
                    return respuesta;
                }
            });
        }

        private Task<IAutorDTO> CrearAutor(IAutorDTO autorDTO)
        {
            return this.repositorioAutor.Value.AgregarAutor(autorDTO);
        }

        private Task<List<IAutorDTO>> ConsultarAutorPorIdentificacion(IAutorDTO autorDTO)
        {
            return this.repositorioAutor.Value.ConsultarListaAutorPorFiltro(x=> x.Identificacion == autorDTO.Identificacion);
        }


        //private bool ValidarInformacionEntrada(IAutorDTO autorDTO)
        //{
        //}
    }
}
