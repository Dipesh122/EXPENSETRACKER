using ExpenseTracker.Core.pagination;

namespace ExpenseTracker.Core.Servie
{

    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}