using FluentValidation;

namespace MovieStore.Aplication.ActorOperation.Commands.CreateActor;

public class CreateActorCommandValidation : AbstractValidator<CreateActorCommand>
{
    public CreateActorCommandValidation()
    {
        RuleFor(command=>command.Model.Name).MinimumLength(2).NotEmpty();
        RuleFor(command=>command.Model.Surname).MinimumLength(2).NotEmpty();
        RuleFor(command=>command.Model.MoviesPlayed).NotEmpty();
    }

}