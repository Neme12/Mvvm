using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Commands.Tests
{
    public abstract class CommandSharedTest
    {
        protected void ThrowsExecuteNull(Action action)
        {
            Assert.AreEqual("execute", Assert.ThrowsException<ArgumentNullException>(action).ParamName);
        }
    }
}
