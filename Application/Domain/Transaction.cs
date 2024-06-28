namespace Application.Domain;

public class Transaction
{
    public int Id { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime OccurrenceAt { get; set; }
    public decimal Value { get; set; }
    public required string LegalDocument { get; set; }
    public required string CardNumber { get; set; }
    public required string StoreOwner { get; set; }
    public required string StoreName { get; set; }
    public DateTime CreatedAt { get; set; }
}
