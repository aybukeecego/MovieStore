using FluentValidation;

namespace MovieStore.Aplication.DirectorOperation.Commands.UpdateDirector;

public class UpdateDirectorCommandValidation : AbstractValidator<UpdateDirectorCommand>
{
    public UpdateDirectorCommandValidation()
    {
        RuleFor(command=>command.directorId).GreaterThan(0);
        RuleFor(command=>command.Model.Name).MinimumLength(2).NotEmpty();
        RuleFor(command=>command.Model.Surname).NotEmpty().MaximumLength(2);
        RuleFor(command=>command.Model.MoviesDirected).NotEmpty();
    }
}