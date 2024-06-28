using Application.Domain;

namespace Application.Features.Transactions.Models;

public class TransactionsModel(string storeName, IEnumerable<Transaction> transactions)
{
    public string StoreName { get; } = storeName;
    public decimal Total => Transactions.Sum(it => it.Value);
    public IEnumerable<Transaction> Transactions { get; } = transactions;
}