using System;

namespace MyBooks.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Title   { get; set; }
    public string? Isbn { get; set; }

    public List<Book>? Books { get; set; }
    

}
