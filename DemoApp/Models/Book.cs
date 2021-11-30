﻿namespace DemoApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
