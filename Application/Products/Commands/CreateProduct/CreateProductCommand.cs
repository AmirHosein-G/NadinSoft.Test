using Domain.Dto.ProductDtos;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(CreateProductDto product) : IRequest<bool>;
