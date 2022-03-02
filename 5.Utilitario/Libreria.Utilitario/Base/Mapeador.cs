namespace Libreria.Utilitario.Base
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    public static class Mapeador
    {
        public static TDestino MapearEntidadDTO<TOrigen, TDestino>(this TOrigen origen, TDestino destino)
           where TDestino : TOrigen, new()
        {
            if (origen == null)
            {
                destino = default(TDestino);
            }
            else
            {
                if (destino == null)
                {
                    destino = new TDestino();
                }
            }

            foreach (PropertyInfo propiedadOrigen in origen.GetType().GetProperties())
            {
                PropertyInfo propiedadDestino = destino.GetType().GetProperties().Where(p => p.Name == propiedadOrigen.Name).FirstOrDefault();
                if (propiedadDestino != null && propiedadDestino.GetType().Name == propiedadOrigen.GetType().Name)
                {
                    propiedadDestino.SetValue(destino, propiedadOrigen.GetValue(origen));
                }
            }
            return destino;
        }

        public static Expression<Func<TDestino, bool>> MapearExpresion<TOrigen, TDestino>(Expression<Func<TOrigen, bool>> expresion) where TDestino : TOrigen
        {
            ParameterExpression parametro = Expression.Parameter(typeof(TDestino));
            Expression body = new Visitor(parametro).Visit(expresion.Body);
            return Expression.Lambda<Func<TDestino, bool>>(body, parametro);
        }

        private class Visitor : ExpressionVisitor
        {
            private ParameterExpression _parameter;

            public Visitor(ParameterExpression parameter)
            {
                _parameter = parameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _parameter;
            }
        }
    }
}
