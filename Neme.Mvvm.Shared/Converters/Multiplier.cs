using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Converters
{
    public class Multiplier : TwoWayConverter<double, double>
    {
        public double Factor { get; set; }

        public override double Convert(double value) => value * Factor;

        public override double ConvertBack(double value) => value / Factor;
    }
}
