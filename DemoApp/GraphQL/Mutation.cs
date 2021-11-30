using DemoApp.Data;
using DemoApp.Dtos;
using DemoApp.GraphQL.Errors;
using DemoApp.Models;
using HotChocolate.Subscriptions;

namespace DemoApp.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(DemoContext))]
        public async Task<Author> AddAuthorAsync(
            CreateAuthor input, 
            [ScopedService] DemoContext context, 
            [Service] ITopicEventSender eventSender
        )
        {
            var author = new Author { Name = input.Name };

            context.Authors.Add(author);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnAuthorAdded), author);

            return author;
        }

        [UseDbContext(typeof(DemoContext))]
        public async Task<Book> AddBookAsync(CreateBook input, [ScopedService] DemoContext context)
        {
            var book = new Book
            {
                Title = input.Title,
                PublicationYear = input.PublicationYear,
                AuthorId = input.AuthorId
            };

            context.Books.Add(book);
            await context.SaveChangesAsync();

            return book;
        }

        [UseDbContext(typeof(DemoContext))]
        public async Task<Author> UpdateAuthorAsync(int id, UpdateAuthor input, [ScopedService] DemoContext context)
        {
            var author = await context.Authors.FindAsync(id);

            if (author == null) throw new AppException($"Autor com id: {id} não encontrado");

            author.Name = input.Name;

            await context.SaveChangesAsync();

            return author;
        }

        [UseDbContext(typeof(DemoContext))]
        public async Task<Book> UpdateBookAsync(int id, UpdateBook input, [ScopedService] DemoContext context)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null) throw new AppException($"Livro com id: {id} não encontrado");

            book.Title = input.Title;
            book.PublicationYear = input.PublicationYear;
            book.AuthorId = input.AuthorId;

            await context.SaveChangesAsync();

            return book;
        }

        [UseDbContext(typeof(DemoContext))]
        public async Task<Author> DeleteAuthorAsync(int id, [ScopedService] DemoContext context)
        {
            var author = await context.Authors.FindAsync(id);

            if (author == null) throw new AppException($"Autor com id: {id} não encontrado");

            context.Remove(author);
            await context.SaveChangesAsync();

            return author;
        }

        [UseDbContext(typeof(DemoContext))]
        public async Task<Book> DeleteBookAsync(int id, [ScopedService] DemoContext context)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null) throw new AppException($"Livro com id: {id} não encontrado");

            context.Books.Remove(book);
            await context.SaveChangesAsync();

            return book;
        }
    }
}
