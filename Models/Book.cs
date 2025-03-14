using System;

namespace MyBooks.Models;
using MyBooks.Models;
public class Book
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Isbn { get; set; }
    public string? Author { get; set; }
    public DateTime Published{ get; set; }

}
