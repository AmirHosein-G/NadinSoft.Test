using Domain.Dto.Identity;
using MediatR;

namespace Application.dentity.Queries.GetUser;

public sealed record LoginQuery(string UserName, string Password) : IRequest<LoginResponce>;
