using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Aplication.DirectorOperation.Commands.CreateDirector;
using MovieStore.Aplication.DirectorOperation.Commands.DeleteDirector;
using MovieStore.Aplication.DirectorOperation.Commands.UpdateDirector;
using MovieStore.Aplication.DirectorOperation.Queries.GetDirectors;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;
[ApiController]
[Route("[controller]")]
public class DirectorsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public DirectorsController(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]

    public IActionResult GetDirectors()
    {
        GetDirectorQuery query= new GetDirectorQuery(_mapper,_context);
        var result= query.Handle();

        return Ok(result);
    }

    [HttpPost]

    public IActionResult AddDirector([FromBody] CreateDirectorCommandModel newDirector)
    {
        CreateDirectorCommand command= new CreateDirectorCommand(_mapper,_context);
        command.Model=newDirector;

        CreateDirectorCommandValidation validator= new CreateDirectorCommandValidation();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpPut]

    public IActionResult UpdateDirector([FromBody] UpdateDirectorCommandModel updateDirector, int id)
    {
        UpdateDirectorCommand command=new UpdateDirectorCommand(_mapper,_context);
        command.directorId=id;
        command.Model=updateDirector;
        UpdateDirectorCommandValidation validator=new UpdateDirectorCommandValidation();
        validator.ValidateAndThrow(command);
        command.Handle();

        return Ok();

    }
    
    [HttpDelete]

    public IActionResult DeleteDirector(int id)
    {
        DeleteDirectorCommand command=new DeleteDirectorCommand(_context);
        command.directorId=id;
        command.Handle();
        return Ok();


    }

}