using System.Data;
using FluentValidation;

namespace MovieStore.Aplication.CustomerOperation.Commands.CreateCustomer;

public class CreateCustomerCommandValidation :AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidation()
    {
        RuleFor(command =>command.Model.Name).MaximumLength(2).NotEmpty();
        RuleFor(command =>command.Model.Surname).MaximumLength(0).NotEmpty();

    }

}