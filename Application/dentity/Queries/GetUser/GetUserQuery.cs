using Domain.Dto.Identity;
using MediatR;

namespace Application.dentity.Queries.GetUser;

public sealed record GetUserQuery(string userName, string password) : IRequest<GetUserResponce>;
