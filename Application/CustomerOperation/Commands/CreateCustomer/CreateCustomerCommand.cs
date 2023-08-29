using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.CustomerOperation.Commands.CreateCustomer;

public class CreateCustomerCommand
{
    public CreateCustomerCommandModel Model {get;set;}
    private readonly IMapper _mapper;
    private readonly IMovieStoreDbContext _context;

    public CreateCustomerCommand(IMapper mapper, IMovieStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public void Handle()
    {
        var customer=_context.Customers.SingleOrDefault(x=>x.Name==Model.Name && x.Surname==Model.Surname);
        if(customer is not null)
        throw new InvalidOperationException("Eklemek istediğiniz müşteri zaten mevcut");

        customer=_mapper.Map<Customer>(Model);

        _context.Customers.Add(customer);
        _context.SaveChanges();

    }

}
public class CreateCustomerCommandModel
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public List<string> FavoriteGenres { get; set; }

}