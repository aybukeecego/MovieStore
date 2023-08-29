using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.DirectorOperation.Commands.UpdateDirector;

public class UpdateDirectorCommand
{
    public UpdateDirectorCommandModel Model { get; set; }
    public int directorId { get; set; }
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public UpdateDirectorCommand(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public void Handle()
    {
        var director=_context.Directors.SingleOrDefault(x=>x.Id==directorId);
        if(director is null)
        throw new InvalidOperationException("Güncellenilecek ürün bulunamadı");

        director.Name=Model.Name != default ? Model.Name : director.Name;
        director.Surname=Model.Surname != default ? Model.Surname : director.Surname;
        director.MoviesDirected=Model.MoviesDirected != default ? Model.MoviesDirected : director.MoviesDirected;
        
        _context.SaveChanges();

    }


}
public class UpdateDirectorCommandModel
{
    
    public string Name { get; set; }

    public string Surname { get; set; }

    public List<Movie> MoviesDirected { get; set; }
}