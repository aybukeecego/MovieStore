using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace MovieStore.Aplication.ActorOperation.Queries.GetActors;

public class GetActorQuery 
{
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;
    public GetActorQuery(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public List<GetActorQueryViewModel> Handle()
    {
        var actorList=_context.Actors.Include(x =>x.MoviesPlayed).OrderBy(x=>x.Id).ToList<Actor>();
        List<GetActorQueryViewModel> vm = _mapper.Map<List<GetActorQueryViewModel>>(actorList);

        return vm;
    }
}
public class GetActorQueryViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<Movie> MoviesPlayed { get; set; }
}