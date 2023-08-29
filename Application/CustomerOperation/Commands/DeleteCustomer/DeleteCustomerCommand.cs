using MovieStore.DbOperations;

namespace MovieStore.Aplication.CustomerOperation.Commands.DeleteCustomer;

public class DeleteCustomerCommand
{
    public int customerId { get; set; }
    private readonly IMovieStoreDbContext _context;
    public DeleteCustomerCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var customer= _context.Customers.SingleOrDefault(x=>x.Id==customerId);
        if(customer is null)
        throw new InvalidOperationException("Silmek istediğiniz ürün bulunamadı");

        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }
}