using Domain.Dto.ProductDtos;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(CreateProductDto Product, int UserId) : IRequest<bool>;
