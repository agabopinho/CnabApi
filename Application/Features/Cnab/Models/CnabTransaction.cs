using Application.Domain;
using Application.Features.Cnab.FileHelpersConverters;
using FileHelpers;

namespace Application.Features.Cnab.Models;

[FixedLengthRecord(FixedMode.AllowLessChars)]
public class CnabTransaction
{
    [FieldFixedLength(1)]
    public TransactionType TransactionType { get; set; }

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public DateTime OccurrenceAt { get; set; }

    [FieldFixedLength(10)]
    [FieldConverter(typeof(MoneyConverter))]
    public decimal Value { get; set; }

    [FieldFixedLength(11)]
    [FieldTrim(TrimMode.Both)]
    public required string LegalDocument { get; set; }

    [FieldFixedLength(12)]
    [FieldTrim(TrimMode.Both)]
    public required string CardNumber { get; set; }

    [FieldFixedLength(6)]
    [FieldConverter(typeof(TimeSpanConverter))]
    public TimeSpan Time { get; set; }

    [FieldFixedLength(14)]
    [FieldTrim(TrimMode.Both)]
    public required string StoreOwner { get; set; }

    [FieldFixedLength(19)]
    [FieldTrim(TrimMode.Both)]
    public required string StoreName { get; set; }
}
