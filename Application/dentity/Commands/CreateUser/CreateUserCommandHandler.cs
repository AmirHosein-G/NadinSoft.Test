using Domain.Abstractions;
using Domain.Entiys;
using MediatR;

namespace Application.dentity.Commands.CreateUser;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IIdentityWriteRepository _identityWriteRepository;

    public CreateUserCommandHandler(IIdentityWriteRepository identityWriteRepository)
    {
        _identityWriteRepository = identityWriteRepository;
    }

    public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        User user = new(command.User.UserName, command.User.Password);

        await _identityWriteRepository.InsertAsync(user, cancellationToken);

        return await _identityWriteRepository.SaveChangesAsync(cancellationToken);
    }
}

