using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Neme.Mvvm.Converters
{
    public abstract class FullConverter<T1, T2> : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language) => Convert((T1)value);

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language) => ConvertBack((T2)value);

        public abstract T2 Convert(T1 value);

        public abstract T1 ConvertBack(T2 value);
    }
}
