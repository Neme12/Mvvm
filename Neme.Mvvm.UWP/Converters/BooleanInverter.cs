using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Converters
{
    public class BooleanInverter : FullConverter<bool, bool>
    {
        public override bool Convert(bool value) => !value;

        public override bool ConvertBack(bool value) => !value;
    }
}
