using MediatR;

namespace Application.Products.Commands.CreateProduct;

public sealed record DeleteProductCommand(int ProductId, int UserId) : IRequest<bool>;
