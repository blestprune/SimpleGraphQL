using DemoApp.Data;
using DemoApp.Models;

namespace DemoApp.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(DemoContext)), UseProjection, UseFiltering, UseSorting]
        public IQueryable<Author> GetAuthors([ScopedService] DemoContext context) => context.Authors;

        [UseDbContext(typeof(DemoContext)), UseProjection, UseFiltering, UseSorting]
        public IQueryable<Book> GetBooks([ScopedService] DemoContext context) => context.Books;
    }
}
