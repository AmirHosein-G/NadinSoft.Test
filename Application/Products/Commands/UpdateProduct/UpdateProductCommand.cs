using Domain.Dto.ProductDtos;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public sealed record UpdateProductCommand(UpdateProductDto Product, int UserId) : IRequest<bool>;
