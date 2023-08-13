using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.MovieOperation.Queries.GetMovies;

public class GetMoviesQuery
{
    public GetMoviesViewModel Model { get; set; }
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper=mapper;
    }

    public List<GetMoviesViewModel> Handle()
    {
        var movieList= _context.Movies.Include(x => x.Director).Include(x => x.Actors).OrderBy(x => x.Id).ToList<Movie>();
        List<GetMoviesViewModel> vm= _mapper.Map<List<GetMoviesViewModel>>(movieList);
        return vm;

    }
}
public class GetMoviesViewModel
{   
    public string Name { get; set; }
    public string Year { get; set; }

    public string Genre { get; set; }

    public Director Director { get; set; }

    public List<Actor> Actors { get; set; }
    public decimal Price { get; set; }

}