using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace Neme.Mvvm.Converters
{
    [ContentProperty(Name = nameof(Converters))]
    public class CombinedConverter : IValueConverter
    {
        public List<IValueConverter> Converters { get; } = new List<IValueConverter>();

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            for (int i = 0; i < Converters.Count; ++i)
                value = Converters[i].Convert(value, null, null, language);

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            for (int i = Converters.Count - 1; i >= 0; --i)
                value = Converters[i].ConvertBack(value, null, null, language);

            return value;
        }
    }
}
