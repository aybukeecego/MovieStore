using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DbOperations;

public class MovieStoreDbContext : DbContext
{
    public MovieStoreDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Order> Orders { get; set; }
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }


}