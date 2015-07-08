using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Tests
{
    public abstract class AutomaticCommandSharedTest : CommandSharedTest
    {
        protected void TestCanExecute(AutomaticCommandShared defaultCommand, Func<Func<bool>, AutomaticCommandShared> createCanExecuteCommand)
        {
            Assert.IsTrue(defaultCommand.CanExecute(null));

            bool canExecute = true;
            var canExecuteCommand = createCanExecuteCommand(() => canExecute);

            canExecute = false;
            Assert.IsFalse(canExecuteCommand.CanExecute(null));

            canExecute = true;
            Assert.IsTrue(canExecuteCommand.CanExecute(null));
        }
        
        protected void TestCanExecuteChanged(AutomaticCommandShared command)
        {
            command.RaiseCanExecuteChanged();
            command.RaiseCanExecuteChanged(default(object), default(EventArgs));

            int timesCalled = 0;

            command.CanExecuteChanged += (sender, e) => {
                Assert.AreEqual(command, sender);
                Assert.AreEqual(EventArgs.Empty, e);
                timesCalled += 1;
            };

            command.RaiseCanExecuteChanged();
            Assert.AreEqual(1, timesCalled);

            command.RaiseCanExecuteChanged(default(object), default(EventArgs));
            Assert.AreEqual(2, timesCalled);
        }
    }
}
