using Domain.Dto.Identity;
using MediatR;

namespace Application.dentity.Commands.CreateUser;

public sealed record CreateUserCommand(CreateUserDto User) : IRequest<bool>;

