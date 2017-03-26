using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Converters.Tests
{
    class FullConverterClass<T1, T2> : FullConverter<T1, T2>
    {
        public Func<T1, T2> ConvertImplementation { get; set; }
        public Func<T2, T1> ConvertBackImplementation { get; set; }

        public override T2 Convert(T1 value) => ConvertImplementation(value);
        public override T1 ConvertBack(T2 value) => ConvertBackImplementation(value);
    }
}
