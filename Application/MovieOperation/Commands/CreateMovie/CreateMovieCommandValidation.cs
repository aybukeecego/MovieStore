using FluentValidation;

namespace MovieStore.Aplication.MovieOperation.Commands.CreateMovie;

public class CreateMovieCommandValidation : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidation()
    {
        RuleFor(command =>command.Model.Price).GreaterThan(0).NotEmpty();
        RuleFor(command => command.Model.Name).MinimumLength(1).NotEmpty();
        RuleFor(command =>command.Model.Director).NotEmpty();
        RuleFor(command =>command.Model.Actors).NotEmpty();
        RuleFor(command =>command.Model.Genre).NotEmpty();
    }
}