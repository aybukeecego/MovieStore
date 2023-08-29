using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.ActorOperation.Commands.UpdateActor;

public class UpdateActorCommand
{
    public UpdateActorCommandModel Model { get; set; }
    public int actorId { get; set; }
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public UpdateActorCommand(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public void Handle()
    {
        var actor=_context.Actors.SingleOrDefault(x=>x.Id==actorId);
        if(actor is null)
        throw new InvalidOperationException("Güncellemek istediğiniz aktör bulunamamıştır");

        actor.Name=Model.Name != default ? Model.Name: actor.Name;
        actor.Surname=Model.Surname != default ? Model.Surname : actor.Surname;
        actor.MoviesPlayed=Model.MoviesPlayed != default ? Model.MoviesPlayed : actor.MoviesPlayed;

        _context.SaveChanges();

    }

}
public class UpdateActorCommandModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Movie> MoviesPlayed { get; set; }
}