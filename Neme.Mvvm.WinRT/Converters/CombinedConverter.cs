using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Neme.Mvvm.Converters
{
    public class CombinedConverter : List<IValueConverter>, IValueConverter
    {
        private IEnumerable<IValueConverter> converters => this;
        private IEnumerable<IValueConverter> convertersReversed => (this as IEnumerable<IValueConverter>).Reverse();

        public object Convert(object value, Type targetType, object parameter, string language) =>
            converters.Aggregate(value, (current, converter) => converter.Convert(current, null, null, language));

        public object ConvertBack(object value, Type targetType, object parameter, string language) =>
            convertersReversed.Aggregate(value, (current, converter) => converter.ConvertBack(current, null, null, language));
    }
}
