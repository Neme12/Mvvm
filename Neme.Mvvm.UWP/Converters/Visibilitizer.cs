using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Neme.Mvvm.Converters
{
    public class Visibilitizer : TwoWayConverter<bool, Visibility>
    {
        public override Visibility Convert(bool value) => value ? Visibility.Visible : Visibility.Collapsed;

        public override bool ConvertBack(Visibility value) => value == Visibility.Visible;
    }
}
