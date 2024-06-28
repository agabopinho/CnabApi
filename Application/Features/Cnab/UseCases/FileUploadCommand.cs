using MediatR;

namespace Application.Features.Cnab.UseCases;

public class FileUploadCommand : IRequest
{
    public required Stream Stream { get; set; }
}
