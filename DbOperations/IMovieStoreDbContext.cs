using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DbOperations;

public interface IMovieStoreDbContext
{
    DbSet<Actor> Actors {get;set;}
    DbSet<Customer> Customers {get;set;}
    DbSet<Director> Directors {get;set;}
    DbSet<Movie> Movies {get;set;}
    DbSet<Order> Orders {get;set;}
    int SaveChanges();





}