using Application.Features.Transactions.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnabApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetTransactionsQuery(), cancellationToken));
    }
}
