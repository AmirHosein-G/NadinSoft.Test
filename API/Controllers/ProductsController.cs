using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProducts;
using AutoMapper;
using Domain.Dto.ProductDtos;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public partial class ProductsController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet("GetProducts")]
    public async Task<ActionResult> GetProducts([FromQuery] GetProducsDto model,CancellationToken cancellationToken)
    {
        try
        {
            ProductsResponce result = await mediator.Send(new GetProductsQuery(model.UserId), cancellationToken);

            return Ok(mapper.Map<List<ProductDto>>(result.Products));
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
