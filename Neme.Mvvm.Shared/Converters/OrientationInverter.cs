using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if WPF
using System.Windows.Controls;
#else
using Windows.UI.Xaml.Controls;
#endif

namespace Neme.Mvvm.Converters
{
    public class OrientationInverter : TwoWayConverter<Orientation, Orientation>
    {
        public override Orientation Convert(Orientation value)
        {
            switch (value)
            {
                case Orientation.Horizontal: return Orientation.Vertical;
                case Orientation.Vertical: return Orientation.Horizontal;
                default: throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public override Orientation ConvertBack(Orientation value) => Convert(value);
    }
}
