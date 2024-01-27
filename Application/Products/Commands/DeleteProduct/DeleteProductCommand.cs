using Domain.Dto.ProductDtos;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public sealed record DeleteProductCommand(int productId, int userId) : IRequest<bool>;
