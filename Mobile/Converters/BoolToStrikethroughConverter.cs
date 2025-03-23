using System.Globalization;
using Microsoft.Maui.Controls;

namespace Mobile.Converters
{
    public class BoolToStrikethroughConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo? culture)
        {
            return (value is bool boolValue && boolValue) ? TextDecorations.Strikethrough : TextDecorations.None;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo? culture)
        {
            throw new NotImplementedException();
        }
    }
}