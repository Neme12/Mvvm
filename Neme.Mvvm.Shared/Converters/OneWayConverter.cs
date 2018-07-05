using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if WPF
using System.Windows.Data;
using ConverterLanguage = System.Globalization.CultureInfo;
#else
using Windows.UI.Xaml.Data;
using ConverterLanguage = System.String;
#endif

namespace Neme.Mvvm.Converters
{
    public abstract class OneWayConverter<T1, T2> : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, ConverterLanguage language) =>
            Convert((T1)value);

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, ConverterLanguage language) =>
            throw new NotSupportedException();

        public abstract T2 Convert(T1 value);
    }
}
