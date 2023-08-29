using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.ActorOperation.Commands.CreateActor;

public class CreateActorCommand
{
    public CreateActorCommandModel Model { get; set; }
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var actor=_context.Actors.SingleOrDefault(x=>x.Name==Model.Name && x.Surname==Model.Surname);
        if(actor is not null)
        throw new InvalidOperationException("Eklemek istediğiniz oyuncu zaten mevcut");

        actor=_mapper.Map<Actor>(Model);
        _context.Actors.Add(actor);
        _context.SaveChanges();
    }

}
public class CreateActorCommandModel
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<Movie> MoviesPlayed { get; set; }
    
}