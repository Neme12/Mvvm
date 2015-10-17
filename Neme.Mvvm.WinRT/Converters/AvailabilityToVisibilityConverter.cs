using Neme.Mvvm.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Neme.Mvvm.Converters
{
    public class AvailabilityToVisibilityConverter : ForwardConverter<Availability, Visibility>
    {
        public override Visibility Convert(Availability value) =>
            value == Availability.Hidden ? Visibility.Collapsed : Visibility.Visible;
    }
}
