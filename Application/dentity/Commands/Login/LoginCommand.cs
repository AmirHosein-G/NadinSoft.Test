using Domain.Dto.Identity;
using MediatR;

namespace Application.dentity.Commands.Login;

public sealed record LoginCommand(string UserName, string Password) : IRequest<LoginResponce>;
