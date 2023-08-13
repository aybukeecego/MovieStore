using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DbOperations;

public class DataGenerator 
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MovieStoreDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
        {
            // Look for any book.
            if (context.Movies.Any())
            {
                return;   // Data was already seeded
            }
            context.Movies.AddRange(
                new Movie
                {
                    Name="OpenHaimer",
                    Year= "2023",
                    Genre="Science Fiction",
                    Director="Christopher Nolan",

                }
            );

            context.SaveChanges();
        }
    }
}