using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Aplication.MovieOperation.Commands.CreateMovie;
using MovieStore.Aplication.MovieOperation.Commands.DeleteMovie;
using MovieStore.Aplication.MovieOperation.Commands.UpdateMovie;
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
    [HttpPost]

    public IActionResult AddMovie([FromBody] CreateMovieCommandModel newMovie)
    {
        CreateMovieCommand command=new CreateMovieCommand(_mapper,_context);
        command.Model=newMovie;
        CreateMovieCommandValidation validator= new CreateMovieCommandValidation();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();

    }
    [HttpPut ("{id}")]

    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieCommandModel updateMovie)
    {
        UpdateMovieCommand command= new UpdateMovieCommand(_context);
        command.movieId=id;
        command.Model=updateMovie;
        UpdateMovieCommandValidation validator= new UpdateMovieCommandValidation();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteMovie(int id)
    {
        DeleteMovieCommand command =new DeleteMovieCommand(_context);
        command.movieId=id;
        DeleteMovieCommandValidation validator= new DeleteMovieCommandValidation();
        validator.ValidateAndThrow(command);
        command.Handle();

        return Ok();
    }

}