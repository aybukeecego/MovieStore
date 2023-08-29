using FluentValidation;

namespace MovieStore.Aplication.DirectorOperation.Commands.CreateDirector;

public class CreateDirectorCommandValidation : AbstractValidator<CreateDirectorCommand>
{
    public CreateDirectorCommandValidation()
    {
        RuleFor(command=>command.Model.Name).MinimumLength(2).NotEmpty();
        RuleFor(command=>command.Model.Surname).NotEmpty().MaximumLength(2);
        RuleFor(command=>command.Model.MoviesDirected).NotEmpty();
    }

}