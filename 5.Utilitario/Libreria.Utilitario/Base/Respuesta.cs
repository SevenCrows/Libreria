namespace Libreria.Utilitario.Base
{
    using System.Collections.Generic;
    public class Respuesta<T>
    {
        public bool Resultado { get; set; }
        public List<T> Entidades { get; set; }
        public List<string> Mensajes { get; set; }      
        public Respuesta()
        {
            Entidades = new List<T>();
            Mensajes = new List<string>();
        }
    }
}
