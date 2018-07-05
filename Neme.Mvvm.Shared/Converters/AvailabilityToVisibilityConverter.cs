using Neme.Mvvm.Commands;
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
    public class AvailabilityToVisibilityConverter : OneWayConverter<Availability, Visibility>
    {
        public override Visibility Convert(Availability value) =>
            value == Availability.Hidden ? Visibility.Collapsed : Visibility.Visible;
    }
}
