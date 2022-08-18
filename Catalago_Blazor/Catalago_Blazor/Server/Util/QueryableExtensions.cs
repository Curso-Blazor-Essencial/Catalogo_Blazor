using Catalago_Blazor.Client.Shared.Recursos;

namespace Catalago_Blazor.Server.Util
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, Paginacao paginacao)
        {
            return queryable
               .Skip((paginacao.Pagina - 1) * paginacao.QuantidadePorPagina)
               .Take(paginacao.QuantidadePorPagina);
        }
    }
}








