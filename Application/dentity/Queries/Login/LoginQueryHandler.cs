using Application.Abstractions;
using Domain.Abstractions;
using Domain.Dto.Identity;
using MediatR;

namespace Application.dentity.Queries.GetUser;

internal sealed class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponce>
{
    private readonly IIdentityReadRepository _identityReadRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginQueryHandler(
        IIdentityReadRepository identityReadRepository, 
        IJwtProvider jwtProvider)
    {
        _identityReadRepository = identityReadRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginResponce> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        UserDto user = 
            await _identityReadRepository.GetUserAsync(query.UserName, query.Password, cancellationToken) 
            ?? throw new Exception("InvalidUser");

        string token = _jwtProvider.Generate(user, cancellationToken);

        return new LoginResponce(token);
    }
}
