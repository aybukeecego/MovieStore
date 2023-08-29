
using FluentValidation;

namespace MovieStore.Aplication.ActorOperation.Commands.DeleteActor;

public class DeleteActorCommandValidation : AbstractValidator<DeleteActorCommand>
{
    public DeleteActorCommandValidation()
    {
        RuleFor(command=>command.actorId).GreaterThan(0);
    }
}