using FileHelpers;
using System.Globalization;

namespace Application.Features.Cnab.FileHelpersConverters;

public class TimeSpanConverter : ConverterBase
{
    public override object StringToField(string from)
    {
        return TimeSpan.TryParseExact(from, "hhmmss", CultureInfo.InvariantCulture, out var timeSpan) ? timeSpan : default;
    }
}
