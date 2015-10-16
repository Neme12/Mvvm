using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Commands.Tests
{
    [TestClass]
    public class AutomaticCommandOfParameterTest : AutomaticCommandSharedTest
    {
        private readonly Action<int> emptyActionOfInt = (_) => { };

        [TestMethod]
        public void ActionNullThrows()
        {
            ThrowsExecuteNull(() => new AutomaticCommand<int>(null));
        }

        [TestMethod]
        public void TestCanExecute()
        {
            TestCanExecute(
                new AutomaticCommand<int>(emptyActionOfInt),
                canExecute => new AutomaticCommand<int>(emptyActionOfInt, canExecute)
                );
        }

        [TestMethod]
        public void TestCanExecuteChanged()
        {
            TestCanExecuteChanged(new AutomaticCommand<int>(emptyActionOfInt));
        }

        [TestMethod]
        public void TestExecute()
        {
            string calledParameter = null;

            var command = new AutomaticCommand<string>(parameter => calledParameter = parameter);

            Assert.IsNull(calledParameter);
            command.Execute("Parameter");
            Assert.AreEqual("Parameter", calledParameter);
        }
    }
}
