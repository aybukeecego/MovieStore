using FluentValidation;

namespace MovieStore.Aplication.MovieOperation.Commands.UpdateMovie;

public class UpdateMovieCommandValidation : AbstractValidator<UpdateMovieCommand>
{
    public UpdateMovieCommandValidation()
    {
        RuleFor(command =>command.Model.Price).GreaterThan(0).NotEmpty();
        RuleFor(command =>command.Model.Actors).NotEmpty();
        RuleFor(command =>command.Model.Director).NotEmpty();
    }
}