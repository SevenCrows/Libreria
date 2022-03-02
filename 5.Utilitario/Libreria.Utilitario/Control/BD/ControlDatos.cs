namespace Libreria.Utilitario.Control.BD
{
    using System;
    using System.Threading.Tasks;
    using Libreria.Utilitario.Recursos;
    using Microsoft.EntityFrameworkCore;

    public class ControlDatos<TDBContexto> where TDBContexto : DbContext, new()
    {
        public Func<TDBContexto> FuncContexto = new Func<TDBContexto>(() => { return new TDBContexto(); });

        public TDBContexto ContextoBD;

        public ControlDatos()
        {
            ContextoBD = FuncContexto.Invoke();
        }
               

        public async Task<T> EjecutarTransaccionDAL<T, C>(Func<Task<T>> cuerpoEjecutar) where C : class
        {
            T retorno = default(T);
            try
            {
                using (ContextoBD = FuncContexto.Invoke())
                {
                    retorno = await cuerpoEjecutar();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception(rcsUtilitario.MsgErrorConcurrencia);
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }

    }
}
