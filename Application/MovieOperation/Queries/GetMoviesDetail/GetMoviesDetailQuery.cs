using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.MovieOperation.Queries.GetMoviesDetail;

public class GetMoviesDetailQuery
{
    public int movieId { get; set; }
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetMoviesDetailQuery(IMovieStoreDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper=mapper;

    }
    public GetMoviesDetailViewModel Handle()
    {
        var movie= _context.Movies.Include(x =>x.Actors).Include(x => x.Director).Where(movie=>movie.Id==movieId).SingleOrDefault();
        if(movie is null)
        throw new InvalidOperationException("Bu id'ye ait ürün bulunamadı");

        GetMoviesDetailViewModel vm= _mapper.Map<GetMoviesDetailViewModel>(movie);
        return vm;
    }

}
public class GetMoviesDetailViewModel
{
    public string Name { get; set; }
    public string Year { get; set; }

    public string Genre { get; set; }

    public Director Director { get; set; }

    public List<Actor> Actors { get; set; }
    public decimal Price { get; set; }
}