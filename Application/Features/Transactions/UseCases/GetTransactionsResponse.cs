using Application.Domain;
using Application.Features.Transactions.Models;

namespace Application.Features.Transactions.UseCases;

public class GetTransactionsResponse(IReadOnlyDictionary<string, IEnumerable<Transaction>> transactionsPerStore)
{
    public decimal Total => TransactionsPerStore
        .SelectMany(it => it.Transactions)
        .Sum(it => it.Value);

    public IEnumerable<TransactionsModel> TransactionsPerStore { get; }
        = transactionsPerStore.Select(it => new TransactionsModel(it.Key, it.Value));
}
