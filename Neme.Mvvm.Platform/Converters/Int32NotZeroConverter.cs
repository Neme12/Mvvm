using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Converters
{
    public class Int32NotZeroConverter : OneWayConverter<int, bool>
    {
        public override bool Convert(int value) => value != 0;
    }
}
