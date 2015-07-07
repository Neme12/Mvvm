using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neme.TestUtilities;

namespace Neme.Mvvm.Tests
{
    [TestClass]
    public class AutomaticCommandBarCommandTest : CommandSharedTest
    {
        private readonly Action emptyAction = () => { };

        private void TestDefaultAvailability(AutomaticCommandBarCommand defaultCommand)
        {
            Assert.AreEqual(Availability.Available, defaultCommand.Availability);
        }

        private void TestAvailability(Func<Func<Availability>, AutomaticCommandBarCommand> createAvailabilityCommand)
        {
            Availability availability = Availability.Available;
            var command = createAvailabilityCommand(() => availability);

            availability = Availability.Disabled;
            Assert.AreEqual(Availability.Disabled, command.Availability);

            availability = Availability.Hidden;
            Assert.AreEqual(Availability.Hidden, command.Availability);

            availability = Availability.Available;
            Assert.AreEqual(Availability.Available, command.Availability);
        }

        private void TestAvailability(Func<Func<bool>, Func<bool>, AutomaticCommandBarCommand> createAvailabilityCommand)
        {
            bool isVisible = true;
            bool isEnabled = true;
            var command = createAvailabilityCommand(() => isVisible, () => isEnabled);

            isVisible = true;
            isEnabled = false;
            Assert.AreEqual(Availability.Disabled, command.Availability);

            isVisible = false;
            isEnabled = true;
            Assert.AreEqual(Availability.Hidden, command.Availability);

            isVisible = false;
            isEnabled = false;
            Assert.AreEqual(Availability.Hidden, command.Availability);

            isVisible = true;
            isEnabled = true;
            Assert.AreEqual(Availability.Available, command.Availability);
        }

        private void TestIsVisible(Func<Func<bool>, AutomaticCommandBarCommand> createIsVisibleCommand)
        {
            bool isVisible = true;
            var command = createIsVisibleCommand(() => isVisible);

            isVisible = false;
            Assert.AreEqual(Availability.Hidden, command.Availability);

            isVisible = true;
            Assert.AreEqual(Availability.Available, command.Availability);
        }

        private void TestIsEnabled(Func<Func<bool>, AutomaticCommandBarCommand> createIsEnabledCommand)
        {
            bool isEnabled = true;
            var command = createIsEnabledCommand(() => isEnabled);

            isEnabled = false;
            Assert.AreEqual(Availability.Disabled, command.Availability);

            isEnabled = true;
            Assert.AreEqual(Availability.Available, command.Availability);
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

        private void TestExecute(Func<Action, AutomaticCommandBarCommand> createCommand)
        {
            bool called = false;

            var command = createCommand(() => called = true);

            Assert.IsFalse(called);
            command.Execute();
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void TestDefaultConstructor()
        {
            Throws.Exception<NotSupportedException>(() => new AutomaticCommandBarCommand());
        }

        [TestMethod]
        public void ActionNullThrows()
        {
            ThrowsExecuteNull(() => new AutomaticCommandBarCommand(null));
            ThrowsExecuteNull(() => new AutomaticCommandBarCommand(null, null, null));
        }

        [TestMethod]
        public void TestAvailability()
        {
            TestDefaultAvailability(new AutomaticCommandBarCommand(emptyAction));
            TestDefaultAvailability(new AutomaticCommandBarCommand(emptyAction, null, null));

            TestAvailability(availability => new AutomaticCommandBarCommand(emptyAction, availability));
            TestAvailability((isVisible, isEnabled) => new AutomaticCommandBarCommand(emptyAction, isVisible, isEnabled));

            TestIsVisible(isVisible => new AutomaticCommandBarCommand(emptyAction, isVisible, null));
            TestIsEnabled(isEnabled => new AutomaticCommandBarCommand(emptyAction, null, isEnabled));
        }

        [TestMethod]
        public void TestAvailabilityChanged()
        {
            TestAvailabilityChanged(new AutomaticCommandBarCommand(emptyAction));
        }

        [TestMethod]
        public void TestExecute()
        {
            TestExecute(execute => new AutomaticCommandBarCommand(execute));
            TestExecute(execute => new AutomaticCommandBarCommand(execute, null, null));
        }
    }
}
