namespace DataVance.Application.Features.OpeningBalances.DTOs
{
    public class OpeningBalanceLineDto
    {
        public Guid AccountId { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}

