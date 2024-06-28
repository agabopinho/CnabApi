using Application.Features.Cnab.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnabApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController(IMediator mediator) : ControllerBase
{
    [HttpPost("Upload")]
    public async Task<IActionResult> UploadAsync(IFormFile file, CancellationToken cancellationToken)
    {
        await mediator.Send(new FileUploadCommand
        {
            Stream = file.OpenReadStream()
        }, cancellationToken);

        return Ok();
    }
}
