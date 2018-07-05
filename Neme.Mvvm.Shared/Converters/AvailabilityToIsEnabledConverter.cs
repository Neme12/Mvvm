using Neme.Mvvm.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Converters
{
    public class AvailabilityToIsEnabledConverter : OneWayConverter<Availability, bool>
    {
        public override bool Convert(Availability value) =>
            value == Availability.Available;
    }
}
