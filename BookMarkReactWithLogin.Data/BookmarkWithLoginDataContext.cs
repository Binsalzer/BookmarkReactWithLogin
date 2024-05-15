using Microsoft.EntityFrameworkCore;

namespace BookMarkReactWithLogin.Data;

public class BookmarkWithLoginDataContext : DbContext
{
    private readonly string _connectionString;

    public BookmarkWithLoginDataContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.Entity<UsersBookmarks>()
               .HasKey(ub => new { ub.UserId, ub.BookmarkId });
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Bookmark> Bookmarks { get; set; }
    public DbSet<UsersBookmarks> UsersBookmarks { get; set; }
}