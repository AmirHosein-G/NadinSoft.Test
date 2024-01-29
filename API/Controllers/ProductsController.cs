using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProducts;
using Domain.Dto.ProductDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public partial class ProductsController : ControllerBase
{
    public readonly IMediator mediator;
    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet("GetProducts")]
    public async Task<ActionResult> GetProducts([FromQuery] GetProducsDto model,CancellationToken cancellationToken)
    {
        try
        {
            ProductsResponce result = await mediator.Send(new GetProductsQuery(model.UserId), cancellationToken);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [Authorize]
    [HttpPost("Add")]
    public async Task<ActionResult> Add(CreateProductDto product, CancellationToken cancellationToken)
    {
        try
        {
            (bool success, string message) = Validation(product.ManufactureEmail, product.ManufacturePhone);
            if (!success)
            {
                throw new Exception(message);
            }

            string userId = User.Claims.First().Value;

            bool result = await mediator.Send(new CreateProductCommand(product, Convert.ToInt32(userId)), cancellationToken);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [Authorize]
    [HttpPut("Update")]
    public async Task<ActionResult> Update(UpdateProductDto product, CancellationToken cancellationToken)
    {
        try
        {
            (bool success, string message) = Validation(product.ManufactureEmail, product.ManufacturePhone);
            if (!success)
            {
                throw new Exception(message);
            }

            string userId = User.Claims.First().Value;

            bool result = await mediator.Send(new UpdateProductCommand(product, Convert.ToInt32(userId)), cancellationToken);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [Authorize]
    [HttpDelete("Delete")]
    public async Task<ActionResult> Delete(DeleteProductDto model, CancellationToken cancellationToken)
    {
        try
        {
            string userId = User.Claims.First().Value;

            bool result = await mediator.Send(new DeleteProductCommand(model.ProductId, Convert.ToInt32(userId)), cancellationToken);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [NonAction]
    private static (bool, string) Validation(string email, string phoneNumber)
    {
        bool emailIsValid = new EmailAddressAttribute().IsValid(email);
        bool phoneNumberIsValid = Regex.Match(phoneNumber, @"[0-9]").Success;

        if (!emailIsValid || !phoneNumberIsValid)
        {
            if (emailIsValid)
            {
                return (false, "phone number is not valid");
            }
            if (phoneNumberIsValid)
            {
                return (false, "Email is not valid");
            }
            return (false, "Email and phone number are not valid");
        }
        return (true, "Success");
    }

}
