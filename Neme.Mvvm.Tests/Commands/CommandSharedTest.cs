using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neme.TestUtilities;

namespace Neme.Mvvm.Commands.Tests
{
    public abstract class CommandSharedTest
    {
        protected void ThrowsExecuteNull(Action action)
        {
            Throws.ArgumentNullException(action, "execute");
        }
    }
}
