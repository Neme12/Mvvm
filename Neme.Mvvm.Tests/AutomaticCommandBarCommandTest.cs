using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Tests
{
    [TestClass]
    public class AutomaticCommandBarCommandTest : CommandSharedTest
    {
        private readonly Action emptyAction = () => { };

        private void TestAvailability(AutomaticCommandBarCommand defaultCommand, Func<Func<Availability>, AutomaticCommandBarCommand> createAvailabilityCommand)
        {
            Assert.AreEqual(Availability.Available, defaultCommand.Availability);

            Availability availability = Availability.Available;
            var availabilityCommand = createAvailabilityCommand(() => availability);

            availability = Availability.Disabled;
            Assert.AreEqual(Availability.Disabled, availabilityCommand.Availability);

            availability = Availability.Hidden;
            Assert.AreEqual(Availability.Hidden, availabilityCommand.Availability);

            availability = Availability.Available;
            Assert.AreEqual(Availability.Available, availabilityCommand.Availability);
        }

        private void TestAvailabilityChanged(AutomaticCommandBarCommand command)
        {
            command.RaiseAvailabilityChanged();

            int timesCalled = 0;

            command.AvailabilityChanged += (sender, e) => {
                Assert.AreEqual(command, sender);
                Assert.AreEqual(EventArgs.Empty, e);
                timesCalled += 1;
            };

            command.RaiseAvailabilityChanged();
            Assert.AreEqual(1, timesCalled);

            command.RaiseAvailabilityChanged();
            Assert.AreEqual(2, timesCalled);
        }

        [TestMethod]
        public void ActionNullThrows()
        {
            ThrowsExecuteNull(() => new AutomaticCommandBarCommand(null));
        }

        [TestMethod]
        public void TestAvailability()
        {
            TestAvailability(
                new AutomaticCommandBarCommand(emptyAction),
                availability => new AutomaticCommandBarCommand(emptyAction, availability)
                );
        }

        [TestMethod]
        public void TestAvailabilityChanged()
        {
            TestAvailabilityChanged(new AutomaticCommandBarCommand(emptyAction));
        }

        [TestMethod]
        public void TestExecute()
        {
            bool called = false;

            var command = new AutomaticCommandBarCommand(() => called = true);

            Assert.IsFalse(called);
            command.Execute();
            Assert.IsTrue(called);
        }
    }
}
