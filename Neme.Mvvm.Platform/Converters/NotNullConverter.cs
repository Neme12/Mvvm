using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Converters
{
    public class NotNullConverter : OneWayConverter<object, bool>
    {
        public override bool Convert(object value) => value != null;
    }
}
