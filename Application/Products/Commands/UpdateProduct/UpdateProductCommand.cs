using Domain.Dto.ProductDtos;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public sealed record UpdateProductCommand(UpdateProductDto product) : IRequest<bool>;
