
using FluentValidation;

namespace MovieStore.Aplication.ActorOperation.Commands.UpdateActor;

public class UpdateActorCommandValidation : AbstractValidator<UpdateActorCommand>
{
    public UpdateActorCommandValidation()
    {
        RuleFor(command=>command.actorId).GreaterThan(0);
        RuleFor(command=>command.Model.Name).NotEmpty();
        RuleFor(command=>command.Model.Surname).NotEmpty();
        RuleFor(command=>command.Model.MoviesPlayed).NotEmpty();
    }

}