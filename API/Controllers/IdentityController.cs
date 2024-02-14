using Application.dentity.Commands.CreateUser;
using Application.dentity.Commands.Login;
using Domain.Dto.Identity;
using Domain.Entiys;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
                throw new Exception("Upration failure");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromQuery] LoginDto model, CancellationToken cancellationToken)
    {
        try
        {
            LoginResponce result = await mediator.Send(new LoginCommand(model.UserName, model.Password), cancellationToken);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }
}
