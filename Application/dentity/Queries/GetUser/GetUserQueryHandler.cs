using Domain.Abstractions;
using Domain.Dto.Identity;
using MediatR;

namespace Application.dentity.Queries.GetUser;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponce>
{
    private readonly IIdentityReadRepository _identityReadRepository;

    public GetUserQueryHandler(IIdentityReadRepository identityReadRepository)
    {
        _identityReadRepository = identityReadRepository;
    }

    public async Task<GetUserResponce> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        UserDto user = await _identityReadRepository.GetUserAsync(query.userName, query.password, cancellationToken);

        return new GetUserResponce()
        {
            User = user,
        };
    }
}
