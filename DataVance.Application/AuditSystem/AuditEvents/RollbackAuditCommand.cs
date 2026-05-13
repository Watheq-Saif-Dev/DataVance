using MediatR;
namespace DataVance.Application.AuditSystem.AuditEvents
{
    public record RollbackAuditCommand(Guid LogId) : IRequest<bool>;
}
