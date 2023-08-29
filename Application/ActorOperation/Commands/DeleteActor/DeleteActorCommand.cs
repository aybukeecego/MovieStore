using MovieStore.DbOperations;

namespace MovieStore.Aplication.ActorOperation.Commands.DeleteActor;

public class DeleteActorCommand
{
    public int actorId { get; set; }

    private readonly IMovieStoreDbContext _context;

    public DeleteActorCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var actor=_context.Actors.SingleOrDefault(x=>x.Id==actorId);
        if(actor is null)
        throw new InvalidOperationException("Silmek istediğiniz ürün bulunamamıştır");

        _context.Actors.Remove(actor);
        _context.SaveChanges();
    }
}