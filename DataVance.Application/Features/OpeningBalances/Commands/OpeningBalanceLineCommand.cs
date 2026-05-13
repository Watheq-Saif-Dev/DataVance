namespace DataVance.Application.Features.OpeningBalances.Commands
{
    public record OpeningBalanceLineCommand
    {
        public Guid AccountId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}

