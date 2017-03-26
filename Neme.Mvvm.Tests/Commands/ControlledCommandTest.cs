using System;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Commands.Tests
{
    [TestClass]
    public class ControlledCommandTest : ControlledCommandSharedTest
    {
        private readonly Action emptyAction = () => { };

        private ControlledCommand CreateEmpty(bool isEnabled)
        {
            return new ControlledCommand(emptyAction, isEnabled);
        }

        [TestMethod]
        public void ActionNullThrows()
        {
            ThrowsExecuteNull(() => new ControlledCommand(null, true));
        }

        [TestMethod]
        public void TestIsEnabledAndCanExecute()
        {
            TestIsEnabledAndCanExecute(CreateEmpty(true), CreateEmpty(false));
        }

        [TestMethod]
        public void TestCanExecuteChanged()
        {
            TestCanExecuteChanged(CreateEmpty(true));
        }

        [TestMethod]
        public void TestExecute()
        {
            bool called = false;

            var command = new ControlledCommand(() => called = true, true);

            Assert.IsFalse(called);
            command.Execute(null);
            Assert.IsTrue(called);
        }
    }
}
