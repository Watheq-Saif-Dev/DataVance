using MediatR;

namespace DataVance.Application.Features.Warehouses.Commands
{
    public record DeleteWarehouseCommand(Guid Id) : IRequest<bool>;
}
