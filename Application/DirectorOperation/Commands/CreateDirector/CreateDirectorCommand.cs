using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.DirectorOperation.Commands.CreateDirector;

public class CreateDirectorCommand
{
    public CreateDirectorCommandModel Model { get; set; }
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;
    public CreateDirectorCommand(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public void Handle()
    {
        var director =_context.Directors.SingleOrDefault(x=>x.Name==Model.Name && x.Surname==Model.Surname);
        if (director is not null)
        throw new InvalidOperationException("Eklemek istediğiniz yönetmen zaten mevcut");

        director=_mapper.Map<Director>(Model);
        
        _context.Directors.Add(director);
        _context.SaveChanges();

    }

}
public class CreateDirectorCommandModel
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public List<Movie> MoviesDirected { get; set; }
}