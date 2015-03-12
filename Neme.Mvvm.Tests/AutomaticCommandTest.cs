using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Tests
{
    [TestClass]
    public class AutomaticCommandTest : AutomaticCommandSharedTest
    {
        private readonly Action emptyAction = () => { };

        [TestMethod]
        public void ActionNullThrows()
        {
            ThrowsExecuteNull(() => new AutomaticCommand(null));
        }

        [TestMethod]
        public void TestCanExecute()
        {
            TestCanExecute(
                new AutomaticCommand(emptyAction),
                canExecute => new AutomaticCommand(emptyAction, canExecute)
                );
        }

        [TestMethod]
        public void TestCanExecuteChanged()
        {
            TestCanExecuteChanged(new AutomaticCommand(emptyAction));
        }

        [TestMethod]
        public void TestExecute()
        {
            bool called = false;

            var command = new AutomaticCommand(() => called = true);

            Assert.IsFalse(called);
            command.Execute(null);
            Assert.IsTrue(called);
        }
    }
}
