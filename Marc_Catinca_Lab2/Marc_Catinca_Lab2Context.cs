using Microsoft.EntityFrameworkCore;

public class Marc_Catinca_Lab2Context(DbContextOptions<Marc_Catinca_Lab2Context> options) : DbContext(options)
{
    public DbSet<Marc_Catinca_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Marc_Catinca_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Marc_Catinca_Lab2.Models.Author> Author { get; set; } = default!;
}
