using MovieStore.DbOperations;

namespace MovieStore.Aplication.DirectorOperation.Commands.DeleteDirector;

public class DeleteDirectorCommand
{
    public int directorId { get; set; }
    private readonly IMovieStoreDbContext _context;
    public DeleteDirectorCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }
    public void Handle()
    {
        var director=_context.Directors.SingleOrDefault(x=>x.Id==directorId);
        if(director is null)
        throw new InvalidOperationException("Silmek istediğiniz ürün bulunamamıştır");

        _context.Directors.Remove(director);
        _context.SaveChanges();
    }
}