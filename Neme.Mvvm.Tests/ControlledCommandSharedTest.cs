using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neme.TestUtilities;

namespace Neme.Mvvm.Tests
{
    public abstract class ControlledCommandSharedTest : CommandSharedTest
    {
        protected void TestIsEnabledAndCanExecute(ControlledCommandShared enabledCommand, ControlledCommandShared disabledCommand)
        {
            Assert.IsTrue(enabledCommand.IsEnabled);
            Assert.IsTrue(enabledCommand.CanExecute(null));

            Assert.IsFalse(disabledCommand.IsEnabled);
            Assert.IsFalse(disabledCommand.CanExecute(null));

            var command = enabledCommand;

            command.IsEnabled = false;
            Assert.IsFalse(command.IsEnabled);
            Assert.IsFalse(command.CanExecute(null));

            command.IsEnabled = true;
            Assert.IsTrue(command.IsEnabled);
            Assert.IsTrue(command.CanExecute(null));
        }

        protected void TestCanExecuteChanged(ControlledCommandShared command)
        {
            int timesCalled = 0;

            command.CanExecuteChanged += (sender, e) => {
                Assert.AreEqual(command, sender);
                Assert.AreEqual(EventArgs.Empty, e);
                timesCalled += 1;
            };

            command.IsEnabled = false;
            Assert.AreEqual(1, timesCalled);

            command.IsEnabled = true;
            Assert.AreEqual(2, timesCalled);
        }
    }
}
