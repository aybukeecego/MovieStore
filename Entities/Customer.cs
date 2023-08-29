namespace MovieStore.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Surname { get; set; }

    public List<string> FavoriteGenres { get; set; }

    public Movie MoviePurchased { get; set; }

}