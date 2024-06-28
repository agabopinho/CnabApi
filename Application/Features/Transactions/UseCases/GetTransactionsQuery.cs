using MediatR;

namespace Application.Features.Transactions.UseCases;

public class GetTransactionsQuery : IRequest<GetTransactionsResponse>
{
}
