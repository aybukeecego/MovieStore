
using FluentValidation;

namespace MovieStore.Aplication.CustomerOperation.Commands.DeleteCustomer;

public class DeleteCustomerCommandValidation : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidation()
    {
        RuleFor(command =>command.customerId).GreaterThan(0);
    }

}