using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Aplication.CustomerOperation.Commands.BuyMovie;

public class BuyMovieCommand
{
    public BuyMovieModel Model {get;set;}
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;


    public BuyMovieCommand(IMovieStoreDbContext context,IMapper mapper)
    {
        _context=context;
        _mapper=mapper;
        
    }

    public void Handle()
    {
        Customer customer=new Customer();

        var movie= _context.Orders.FirstOrDefault(x=>x.Movie==Model.Movie);
        if(movie is not null)
        throw new InvalidOperationException("Satın almak istediğiniz ürün zaten mevcut");

        _context.Orders.Add(movie);
    }

}

public class BuyMovieModel
{
    public Movie Movie { get; set; }

    public string Year { get; set; }
}
