using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if WPF
using System.Windows.Data;
using System.Windows.Markup;
using ConverterLanguage = System.Globalization.CultureInfo;
#else
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using ConverterLanguage = System.String;
#endif

namespace Neme.Mvvm.Converters
{
    [ContentProperty(
#if UWP
        Name =
#endif
        nameof(Converters))]
    public class CombinedConverter : IValueConverter
    {
        public List<IValueConverter> Converters { get; } = new List<IValueConverter>();

        public object Convert(object value, Type targetType, object parameter, ConverterLanguage language)
        {
            for (int i = 0; i < Converters.Count; ++i)
                value = Converters[i].Convert(value, null, null, language);

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, ConverterLanguage language)
        {
            for (int i = Converters.Count - 1; i >= 0; --i)
                value = Converters[i].ConvertBack(value, null, null, language);

            return value;
        }
    }
}
