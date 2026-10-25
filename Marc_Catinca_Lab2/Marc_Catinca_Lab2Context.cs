using Microsoft.EntityFrameworkCore;
using Marc_Catinca_Lab2.Models;

public class Marc_Catinca_Lab2Context : DbContext
{
    public Marc_Catinca_Lab2Context(DbContextOptions<Marc_Catinca_Lab2Context> options)
        : base(options)
    {
    }

    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<Publisher> Publisher { get; set; } = default!;
    public DbSet<Author> Author { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;
    public DbSet<BookCategory> BookCategory { get; set; } = default!;
}
