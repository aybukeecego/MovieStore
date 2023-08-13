using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Aplication.MovieOperation.Queries.GetMovies;
using MovieStore.Aplication.MovieOperation.Queries.GetMoviesDetail;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public MoviesController(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetMovies()
    {
        GetMoviesQuery query= new GetMoviesQuery(_context,_mapper);
         var result=query.Handle();
         return Ok(result);

    }

    [HttpGet ("{id}")]

    public IActionResult GetMoviesDetail(int id)
    {
        GetMoviesDetailQuery query = new GetMoviesDetailQuery(_context,_mapper);

        query.movieId=id;
        GetMoviesDetailQueryValidation validator= new GetMoviesDetailQueryValidation();
        validator.ValidateAndThrow(query);
        var result=query.Handle();
        return Ok(result);

    }

}