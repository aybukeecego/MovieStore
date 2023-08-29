using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Aplication.ActorOperation.Commands.CreateActor;
using MovieStore.Aplication.ActorOperation.Commands.DeleteActor;
using MovieStore.Aplication.ActorOperation.Commands.UpdateActor;
using MovieStore.Aplication.ActorOperation.Queries.GetActors;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public ActorsController(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]

    public IActionResult GetActors()
    {
        GetActorQuery query=new GetActorQuery(_mapper , _context);
        var result=query.Handle();

        return Ok(result);
    }

    [HttpPost]

    public IActionResult AddActor([FromBody]CreateActorCommandModel newActor)
    {
        CreateActorCommand command=new CreateActorCommand(_context,_mapper);
        command.Model=newActor;
        CreateActorCommandValidation validator= new CreateActorCommandValidation();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]

    public IActionResult UpdateActor(int id, [FromBody] UpdateActorCommandModel updateActor )
    {
        UpdateActorCommand command= new UpdateActorCommand(_mapper,_context);
        command.actorId=id;
        command.Model=updateActor;
        UpdateActorCommandValidation validator= new UpdateActorCommandValidation();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpDelete ("{id}")]
    public IActionResult DeleteActor(int id)
    
    {
      DeleteActorCommand command= new DeleteActorCommand(_context);
      command.actorId=id;
      DeleteActorCommandValidation validator= new DeleteActorCommandValidation();
      validator.ValidateAndThrow(command);
      
      command.Handle();
      return Ok();

    }

}