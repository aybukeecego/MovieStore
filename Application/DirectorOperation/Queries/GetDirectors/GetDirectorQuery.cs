using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.DirectorOperation.Queries.GetDirectors;

public class GetDirectorQuery
{
    public GetDirectorQueryViewModel Model { get; set; }
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public GetDirectorQuery(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public List<GetDirectorQueryViewModel> Handle()
    {
        var directorList=_context.Directors.Include(x=>x.MoviesDirected).OrderBy(x=>x.Id).ToList<Director>();
        List<GetDirectorQueryViewModel> vm= _mapper.Map<List<GetDirectorQueryViewModel>>(directorList);
        return vm;

    }

}
public class GetDirectorQueryViewModel
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public List<Movie> MoviesDirected { get; set; }
}