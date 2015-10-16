using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neme.TestUtilities;

namespace Neme.Mvvm.Commands.Tests
{
    [TestClass]
    public class ControlledSmartCommandTest : CommandSharedTest
    {
        private readonly Action emptyAction = () => { };

        private ControlledSmartCommand CreateEmpty(Availability availability) => new ControlledSmartCommand(emptyAction, availability);

        [TestMethod]
        public void ActionNullThrows()
        {
            ThrowsExecuteNull(() => new ControlledSmartCommand(null, Availability.Available));
        }

        [TestMethod]
        public void TestInitialAvailability()
        {
            var availableCommand = CreateEmpty(Availability.Available);
            Assert.AreEqual(Availability.Available, availableCommand.Availability);

            var disabledCommand = CreateEmpty(Availability.Disabled);
            Assert.AreEqual(Availability.Disabled, disabledCommand.Availability);

            var hiddenCommand = CreateEmpty(Availability.Hidden);
            Assert.AreEqual(Availability.Hidden, hiddenCommand.Availability);
        }

        [TestMethod]
        public void TestAvailability()
        {
            var command = CreateEmpty(Availability.Available);

            command.Availability = Availability.Disabled;
            Assert.AreEqual(Availability.Disabled, command.Availability);

            command.Availability = Availability.Hidden;
            Assert.AreEqual(Availability.Hidden, command.Availability);

            command.Availability = Availability.Available;
            Assert.AreEqual(Availability.Available, command.Availability);
        }

        [TestMethod]
        public void TestAvailabilityChanged()
        {
            var command = CreateEmpty(Availability.Available);

            int timesCalled = 0;

            command.AvailabilityChanged += (sender, e) => {
                Assert.AreEqual(command, sender);
                Assert.AreEqual(EventArgs.Empty, e);
                timesCalled += 1;
            };

            command.Availability = Availability.Disabled;
            Assert.AreEqual(1, timesCalled);

            command.Availability = Availability.Hidden;
            Assert.AreEqual(2, timesCalled);

            command.Availability = Availability.Available;
            Assert.AreEqual(3, timesCalled);
        }

        [TestMethod]
        public void TestExecute()
        {
            bool called = false;

            var command = new ControlledSmartCommand(() => called = true, Availability.Available);

            Assert.IsFalse(called);
            command.Execute();
            Assert.IsTrue(called);
        }
    }
}
