namespace Libreria.Utilitario.BD
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;
    using Libreria.Utilitario.Recursos;
    using Microsoft.EntityFrameworkCore;

    public class ControlTransaccion<TDBContexto> where TDBContexto : DbContext, new()
    {
        public Func<TDBContexto> FuncContexto = new Func<TDBContexto>(() => { return new TDBContexto(); });

        public TDBContexto ContextoBD;

        public ControlTransaccion()
        {
            ContextoBD = FuncContexto.Invoke();
        }

        public async Task<T> EjecutarNegocio<T, C>(System.Transactions.IsolationLevel nivelAislamiento, Func<Task<T>> cuerpoEjecutar) where C : class
        {
            T retorno = default(T);

            using (TransactionScope transaccion = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = nivelAislamiento }, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    retorno = await cuerpoEjecutar();

                    transaccion.Complete();
                }
                catch (DbUpdateException ex)
                {
                    var mensajeExcepcion = new StringBuilder();
                    mensajeExcepcion.AppendLine($"DbUpdateException - {ex?.InnerException?.InnerException?.Message}");

                    foreach (var eve in ex.Entries)
                    {
                        mensajeExcepcion.AppendLine($"La Entidad {eve.Entity.GetType().Name} en estado {eve.State} no se puede afectar.");
                    }

                    throw new Exception(mensajeExcepcion.ToString());
                }
                finally
                {
                    transaccion.Dispose();
                }
            }

            return retorno;
        }

        public async Task<T> EjecutarDatos<T, C>(Func<Task<T>> cuerpoEjecutar) where C : class
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
