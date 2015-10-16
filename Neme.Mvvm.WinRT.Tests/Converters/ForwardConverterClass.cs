using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Converters.Tests
{
    class ForwardConverterClass<T1, T2> : ForwardConverter<T1, T2>
    {
        public Func<T1, T2> ConvertImplementation { get; set; }

        public override T2 Convert(T1 value) => ConvertImplementation(value);
    }
}
