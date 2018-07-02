using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Neme.Mvvm.Converters
{
    public abstract class OneWayConverter<T1, T2> : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language) => Convert((T1)value);

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }

        public abstract T2 Convert(T1 value);
    }
}
