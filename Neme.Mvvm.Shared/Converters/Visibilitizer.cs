using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if WPF
using System.Windows;
#else
using Windows.UI.Xaml;
#endif

namespace Neme.Mvvm.Converters
{
    public class Visibilitizer : TwoWayConverter<bool, Visibility>
    {
        public override Visibility Convert(bool value) => value ? Visibility.Visible : Visibility.Collapsed;

        public override bool ConvertBack(Visibility value)
        {
            switch (value)
            {
                case Visibility.Visible: return true;
                case Visibility.Collapsed: return false;
                default: throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
    }
}
