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
    public abstract class TwoWayConverter<T1, T2> : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, ConverterLanguage language) =>
            Convert((T1)value);

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, ConverterLanguage language) =>
            ConvertBack((T2)value);

        public abstract T2 Convert(T1 value);

        public abstract T1 ConvertBack(T2 value);
    }
}
