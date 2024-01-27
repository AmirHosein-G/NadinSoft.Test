using Application.dentity.Commands.CreateUser;
using Application.dentity.Queries.GetUser;
using Domain.Dto.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class IdentityController : ControllerBase
{
    public readonly IMediator mediator;
    public IdentityController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register(CreateUserDto model, CancellationToken cancellationToken)
    {
        try
        {
            bool result = await mediator.Send(new CreateUserCommand(model), cancellationToken);
            if (!result)
            {
                throw new Exception();
            }

            GetUserResponce user = await mediator.Send(new GetUserQuery(model.UserName, model.Password), cancellationToken);

            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("Login")]
    public async Task<ActionResult> Login([FromQuery]LoginDto model, CancellationToken cancellationToken)
    {
        try
        {
            LoginResponce result = await mediator.Send(new LoginQuery(model.UserName, model.Password), cancellationToken);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
