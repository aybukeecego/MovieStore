using FluentValidation;

namespace MovieStore.Aplication.MovieOperation.Queries.GetMoviesDetail;

public class GetMoviesDetailQueryValidation : AbstractValidator<GetMoviesDetailQuery>
{
    public GetMoviesDetailQueryValidation()
    {
        RuleFor(query=>query.movieId).GreaterThan(0);
    }
}