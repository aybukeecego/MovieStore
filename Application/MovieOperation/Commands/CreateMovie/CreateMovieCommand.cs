using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.MovieOperation.Commands.CreateMovie;

public class CreateMovieCommand 
{
    public CreateMovieCommandModel Model {get;set;}
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;
    public CreateMovieCommand(IMapper mapper , IMovieStoreDbContext context)
    {
        _mapper=mapper;
        _context=context;

    }
    public void Handle()
    {
        var movie=_context.Movies.SingleOrDefault(x=> x.Name==Model.Name && x.Director==Model.Director && x.Year==Model.Year);
        if(movie is not null)
        throw new InvalidOperationException("Eklemek istediğiniz kitap zaten mevcut");

        movie=_mapper.Map<Movie>(Model);

        _context.Movies.Add(movie);
        _context.SaveChanges();
    }

}
public class CreateMovieCommandModel
{
    public string Name { get; set; }
    public string Year { get; set; }

    public string Genre { get; set; }

    public Director Director { get; set; }

    public List<Actor> Actors { get; set; }
    public decimal Price { get; set; }

}