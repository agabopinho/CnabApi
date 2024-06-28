using Application.Database;
using Application.Domain;
using Application.Features.Cnab.Models;
using FileHelpers;
using MediatR;

namespace Application.Features.Cnab.UseCases;

public class FileUploadUseCase(ApplicationDbContext context) : IRequestHandler<FileUploadCommand>
{
    private static readonly IReadOnlyDictionary<TransactionType, SignalType> Signals = new Dictionary<TransactionType, SignalType>()
    {
        { TransactionType.Debit, SignalType.Credit },
        { TransactionType.PaymentSplip, SignalType.Debit },
        { TransactionType.Financing, SignalType.Debit },
        { TransactionType.Credit, SignalType.Credit },
        { TransactionType.LoanReceipt, SignalType.Credit },
        { TransactionType.Sales, SignalType.Credit },
        { TransactionType.TEDReceipt, SignalType.Credit },
        { TransactionType.DOCreceipt, SignalType.Credit },
        { TransactionType.Rent, SignalType.Debit },
    };

    public async Task Handle(FileUploadCommand request, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(request.Stream);

        var engine = new FixedFileEngine<CnabTransaction>();
        var result = engine.ReadStream(reader);

        await context.Transactions.AddRangeAsync(result.Select(it => new Transaction
        {
            TransactionType = it.TransactionType,
            OccurrenceAt = it.OccurrenceAt.Add(it.Time),
            Value = Signals[it.TransactionType] == SignalType.Credit ? it.Value : -it.Value,
            LegalDocument = it.LegalDocument,
            CardNumber = it.CardNumber,
            StoreOwner = it.StoreOwner,
            StoreName = it.StoreName,
            CreatedAt = DateTime.Now
        }), cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
    }

    private enum SignalType
    {
        Credit = 1,
        Debit
    }
}