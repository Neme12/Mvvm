using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Converters
{
    public class Objectifier : TwoWayConverter<object, object>
    {
        public override object Convert(object value) => value;

        public override object ConvertBack(object value) => value;
    }
}
