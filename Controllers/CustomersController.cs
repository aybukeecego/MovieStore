using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Aplication.CustomerOperation.Commands.CreateCustomer;
using MovieStore.Aplication.CustomerOperation.Commands.DeleteCustomer;
using MovieStore.Aplication.CustomerOperation.CreateToken;
using MovieStore.DbOperations;
using MovieStore.TokenOperations.Models;

namespace MovieStore.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _confugiration;

    public CustomersController(IMovieStoreDbContext context, IMapper mapper,IConfiguration confugiration)
    {
        _context = context;
        _mapper = mapper;
        _confugiration=confugiration;
    }


    [HttpPost]

    public IActionResult AddCustomer([FromBody] CreateCustomerCommandModel newCustomer)
    {
        CreateCustomerCommand command = new CreateCustomerCommand(_mapper,_context);
        command.Model=newCustomer;
        CreateCustomerCommandValidation validator= new CreateCustomerCommandValidation();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();

    }

    [HttpDelete("{id}")]

    public IActionResult DeleteCustomer(int id)
    {
        DeleteCustomerCommand command=new DeleteCustomerCommand(_context);
        command.customerId=id;
        DeleteCustomerCommandValidation validator= new DeleteCustomerCommandValidation();
        validator.ValidateAndThrow(command);
        command.Handle();

        return Ok();
    }

    [HttpPost("Login")]

    public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
    {
        CreateTokenCommand command=new CreateTokenCommand(_context,_confugiration,_mapper);
        command.Model=login;
        var token=command.Handle();

        return token;

    }

}