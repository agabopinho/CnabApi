using Application.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Transactions.UseCases;

public class GetTransactionsUseCase(ApplicationDbContext context) : IRequestHandler<GetTransactionsQuery, GetTransactionsResponse>
{
    public async Task<GetTransactionsResponse> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactionsPerStore = await context.Transactions
            .GroupBy(it => it.StoreName)
            .ToListAsync(cancellationToken);

        return new(transactionsPerStore.ToDictionary(it => it.Key, it => it.AsEnumerable()));
    }
}
