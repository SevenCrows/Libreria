namespace Libreria.Utilitario.Negocio
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;
    using Microsoft.EntityFrameworkCore;

    public class ControlNegocio
    {
        public async Task<T> EjecutarTransaccionBL<T, C>(System.Transactions.IsolationLevel nivelAislamiento, Func<Task<T>> cuerpoEjecutar) where C : class
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
    }
}
