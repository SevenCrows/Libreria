namespace Libreria.Utilitario.Control.API
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ControlAPI : ControllerBase
    {
        public ControlAPI() { }

        public async Task<T> EjecutarTransaccionAPIAsync<T, C>(Func<Task<T>> cuerpoEjecutar) where C : class
        {
            var cuerpoSolicitud = this.GetBody(HttpContext.Request);
            try
            {
                return await cuerpoEjecutar();
            }
            catch (Exception ex)
            {
                Task<T> manejadorEror = Task.Run(() =>
                {
                    return this.CrearRespuestaError<T>(ex);
                });
                return await manejadorEror;
            }
        }

        private T CrearRespuestaError<T>(Exception ex)
        {
            T retorno = (T)Activator.CreateInstance(typeof(T));
            retorno.GetType().GetProperty("Resultado").SetValue(retorno, false, null);
            retorno.GetType().GetProperty("Mensajes").SetValue(retorno, new List<string> { ex.Message }, null);
            return retorno;
        }

        private string GetBody(HttpRequest solicitud)
        {
            string cuerpo = string.Empty;

            using (StreamReader lector = new StreamReader(solicitud.Body))
            {
                cuerpo = lector.ReadToEnd();

                if (string.IsNullOrEmpty(cuerpo))
                {
                    cuerpo = solicitud.QueryString.ToString();
                }
            }

            return cuerpo;
        }
    }
}
