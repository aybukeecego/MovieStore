using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.MovieOperation.Commands.UpdateMovie;

public class UpdateMovieCommand
{
    public int movieId {get;set;}
    public UpdateMovieCommandModel Model { get; set; }
    private readonly IMovieStoreDbContext _context;

    public UpdateMovieCommand(IMovieStoreDbContext context)
    {
         _context = context;
    }
    public void Handle()
    {
        var movie =_context.Movies.SingleOrDefault(x => x.Id==movieId);
        if(movie is null)
        throw new InvalidOperationException("Aradığınız film bulunamadı");

        movie.Price=Model.Price != default ? Model.Price : movie.Price;
        movie.Actors=Model.Actors != default ? Model.Actors : movie.Actors;
        movie.Director=Model.Director != default ? Model.Director : movie.Director;

        _context.SaveChanges();



    }

}
public class UpdateMovieCommandModel
{
    public List<Actor> Actors { get; set; }
    public decimal Price { get; set; }
    public Director Director { get; set; }
}