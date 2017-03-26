using System;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Commands.Tests
{
    [TestClass]
    public class ControlledCommandOfParameterTest : ControlledCommandSharedTest
    {
        private readonly Action<int> emptyActionOfInt = (_) => { };

        private ControlledCommand<int> CreateEmpty(bool isEnabled) => new ControlledCommand<int>(emptyActionOfInt, isEnabled);

        [TestMethod]
        public void ActionNullThrows()
        {
            ThrowsExecuteNull(() => new ControlledCommand<int>(null, true));
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
            string calledParameter = null;

            var command = new ControlledCommand<string>(parameter => calledParameter = parameter, true);

            Assert.IsNull(calledParameter);
            command.Execute("Parameter");
            Assert.AreEqual("Parameter", calledParameter);
        }
    }
}
