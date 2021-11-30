using DemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Data
{
    public class DemoContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Margaret Atwood" },
                new Author { Id = 2, Name = "Stephen King" },
                new Author { Id = 3, Name = "Jane Austen"},
                new Author { Id = 4, Name = "George Orwell" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, AuthorId = 1, Title = "The Handmaid's Tale", PublicationYear = 1985 },
                new Book { Id = 2, AuthorId = 1, Title = "Alias Grace", PublicationYear = 1996 },
                new Book { Id = 3, AuthorId = 2, Title = "The Shining", PublicationYear = 1977 },
                new Book { Id = 4, AuthorId = 2, Title = "The Stand", PublicationYear = 1978 },
                new Book { Id = 5, AuthorId = 2, Title = "It", PublicationYear = 1986 },
                new Book { Id = 6, AuthorId = 3, Title = "Pride and Prejudice", PublicationYear = 1813 },
                new Book { Id = 7, AuthorId = 3, Title = "Sense and Sensibility", PublicationYear = 1811 },
                new Book { Id = 8, AuthorId = 3, Title = "Emma", PublicationYear = 1816 },
                new Book { Id = 9, AuthorId = 4, Title = "Animal Farm", PublicationYear = 1945 },
                new Book { Id = 10, AuthorId = 4, Title = "Nineteen Eighty-Four", PublicationYear = 1949 }
            );
        }
    }
}
