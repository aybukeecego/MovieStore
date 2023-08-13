namespace MovieStore.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Surname { get; set; }

    public List<string> FavoriteGenres { get; set; }

    public List<Movie> MoviesPurchased { get; set; }
}