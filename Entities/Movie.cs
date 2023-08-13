
namespace MovieStore.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Year { get; set; }

    public string Genre { get; set; }

    public Director Director { get; set; }

    public List<Actor> Actors { get; set; }
    public decimal Price { get; set; }
}