using MediatR;


namespace DataVance.Application.FinanceSystem.Commands
{
    public record ReverseJournalEntryCommand(Guid JournalEntryId, string Reason) : IRequest<bool>;
}
