using Microsoft.EntityFrameworkCore;

using MyBooks.Models;

namespace MyBooks.Data;

public class MyBooksDbContext : DbContext
{
    public MyBooksDbContext(DbContextOptions<MyBooksDbContext> options)
        : base(options) { }

    // EF Core will use these to perform CRUD operations on the database tables for you on the .
    public virtual DbSet<Author>? Authors { get; set; }
    public virtual DbSet<Book>? Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // here we've overridden the method so that we can choose the name of our tables
        // since database tables are supposed to be singular, we name that way here
        // otherwise they'd be plural (e.g. Courses) in the database.
        modelBuilder.Entity<Author>().ToTable("Author");
        modelBuilder.Entity<Book>().ToTable("Book");
    }

}

