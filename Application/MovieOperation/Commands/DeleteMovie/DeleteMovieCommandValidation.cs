using FluentValidation;

namespace MovieStore.Aplication.MovieOperation.Commands.DeleteMovie;

public class DeleteMovieCommandValidation : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidation()
    {
        RuleFor(command =>command.movieId).GreaterThan(0);
    }
}