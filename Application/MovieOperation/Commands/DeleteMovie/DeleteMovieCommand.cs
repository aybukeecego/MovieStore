using MovieStore.DbOperations;

namespace MovieStore.Aplication.MovieOperation.Commands.DeleteMovie;

public class DeleteMovieCommand 
{
    public int movieId { get; set; }
    private readonly IMovieStoreDbContext _context;

    public DeleteMovieCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }
    public void Handle()
    {
        var movie= _context.Movies.SingleOrDefault(x =>x.Id==movieId);
        if(movie==null)
        throw new InvalidOperationException("Silmek istediğiniz ürün bulunamadı");

        _context.Movies.Remove(movie);
        _context.SaveChanges();

    }
}