using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.TokenOperations;
using MovieStore.TokenOperations.Models;

namespace MovieStore.Aplication.CustomerOperation.CreateToken;

public class CreateTokenCommand
{
    public CreateTokenModel Model {get;set;}
    private readonly IMovieStoreDbContext _context;
    private readonly IConfiguration _configuration;

    private readonly IMapper _mapper;

    public CreateTokenCommand(IMovieStoreDbContext context,IConfiguration configuration, IMapper mapper)
    {
         _configuration=configuration;
         _context=context;
         _mapper=mapper;

    }
    public Token Handle()
    {
        var customer= _context.Customers.FirstOrDefault(x=>x.Email==Model.Email|| x.UserName==Model.UserName && x.Password==Model.Password );
        if(customer is not null)
        {
            TokenHandler handler = new TokenHandler(_configuration);
            Token token=handler.CreateAccsessToken(customer);
            _context.SaveChanges();

            return token;
            

        }
        else
        throw new InvalidOperationException("Kullanıcı bilgileri yanlış");
        
    }

}
public class CreateTokenModel
{
    public string Email { get; set; }
    public string UserName { get; set; }

    public string Password { get; set; }

}