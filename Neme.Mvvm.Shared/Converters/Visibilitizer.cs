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
    public class Visibilitizer :
#if WPF
        OneWayConverter<bool, Visibility>
#else
        TwoWayConverter<bool, Visibility>
#endif
    {
        public override Visibility Convert(bool value) => value ? Visibility.Visible : Visibility.Collapsed;

#if UWP
        public override bool ConvertBack(Visibility value) => value == Visibility.Visible;
#endif
    }
}
