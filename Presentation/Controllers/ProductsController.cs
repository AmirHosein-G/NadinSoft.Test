using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProducts;
using Domain.Dto.ProductDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

//[Authorize]
//[Route("api/[controller]")]
//[ApiController]
//public class ProductsController : ControllerBase
//{
//    public readonly IMediator mediator;
//    public ProductsController(IMediator mediator)
//    {
//        this.mediator = mediator;
//    }

//    [AllowAnonymous]
//    [HttpGet("GetProducts")]
//    public async Task<ActionResult> GetProducts(CancellationToken cancellationToken)
//    {
//        try
//        {
//            ProductsResponce result = await mediator.Send(new GetProductsQuery(), cancellationToken);

//            return Ok(result);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(ex.Message);
//        }
//    }
//    [HttpPost("Add")]
//    public async Task<ActionResult> Add(CreateProductDto product, CancellationToken cancellationToken)
//    {
//        try
//        {
//            bool result = await mediator.Send(new CreateProductCommand(product), cancellationToken);

//            return Ok(result);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(ex.Message);
//        }
//    }
//    [HttpPut("Update")]
//    public async Task<ActionResult> Update(UpdateProductDto model, CancellationToken cancellationToken)
//    {
//        try
//        {
//            bool result = await mediator.Send(new UpdateProductCommand(model), cancellationToken);

//            return Ok(result);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(ex.Message);
//        }
//    }
//    [HttpDelete("Delete")]
//    public async Task<ActionResult> Delete(DeleteProductDto model, CancellationToken cancellationToken)
//    {
//        try
//        {
//            bool result = await mediator.Send(new DeleteProductCommand(model.ProductId, model.UserId), cancellationToken);

//            return Ok(result);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(ex.Message);
//        }
//    }
//}
