using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Commands.Tests
{
    [TestClass]
    public class AutomaticSmartCommandTest : CommandSharedTest
    {
        private readonly Action emptyAction = () => { };

        private void TestDefaultAvailability(AutomaticSmartCommand defaultCommand)
        {
            Assert.AreEqual(Availability.Available, defaultCommand.Availability);
        }

        private void TestAvailability(Func<Func<Availability>, AutomaticSmartCommand> createAvailabilityCommand)
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

        private void TestAvailability(Func<Func<bool>, Func<bool>, AutomaticSmartCommand> createAvailabilityCommand)
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

        private void TestIsVisible(Func<Func<bool>, AutomaticSmartCommand> createIsVisibleCommand)
        {
            bool isVisible = true;
            var command = createIsVisibleCommand(() => isVisible);

            isVisible = false;
            Assert.AreEqual(Availability.Hidden, command.Availability);

            isVisible = true;
            Assert.AreEqual(Availability.Available, command.Availability);
        }

        private void TestIsEnabled(Func<Func<bool>, AutomaticSmartCommand> createIsEnabledCommand)
        {
            bool isEnabled = true;
            var command = createIsEnabledCommand(() => isEnabled);

            isEnabled = false;
            Assert.AreEqual(Availability.Disabled, command.Availability);

            isEnabled = true;
            Assert.AreEqual(Availability.Available, command.Availability);
        }

        private void TestAvailabilityChanged(AutomaticSmartCommand command)
        {
            command.RaiseAvailabilityChanged();
            command.RaiseAvailabilityChanged(default(object), default(EventArgs));

            int timesCalled = 0;

            command.AvailabilityChanged += (sender, e) => {
                Assert.AreEqual(command, sender);
                Assert.AreEqual(EventArgs.Empty, e);
                timesCalled += 1;
            };

            command.RaiseAvailabilityChanged();
            Assert.AreEqual(1, timesCalled);

            command.RaiseAvailabilityChanged(default(object), default(EventArgs));
            Assert.AreEqual(2, timesCalled);
        }

        private void TestExecute(Func<Action, AutomaticSmartCommand> createCommand)
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
            Assert.ThrowsException<NotSupportedException>(() => new AutomaticSmartCommand());
        }

        [TestMethod]
        public void ActionNullThrows()
        {
            ThrowsExecuteNull(() => new AutomaticSmartCommand(null));
            ThrowsExecuteNull(() => new AutomaticSmartCommand(null, null, null));
        }

        [TestMethod]
        public void TestAvailability()
        {
            TestDefaultAvailability(new AutomaticSmartCommand(emptyAction));
            TestDefaultAvailability(new AutomaticSmartCommand(emptyAction, null, null));

            TestAvailability(availability => new AutomaticSmartCommand(emptyAction, availability));
            TestAvailability((isVisible, isEnabled) => new AutomaticSmartCommand(emptyAction, isVisible, isEnabled));

            TestIsVisible(isVisible => new AutomaticSmartCommand(emptyAction, isVisible, null));
            TestIsEnabled(isEnabled => new AutomaticSmartCommand(emptyAction, null, isEnabled));
        }

        [TestMethod]
        public void TestAvailabilityChanged()
        {
            TestAvailabilityChanged(new AutomaticSmartCommand(emptyAction));
        }

        [TestMethod]
        public void TestExecute()
        {
            TestExecute(execute => new AutomaticSmartCommand(execute));
            TestExecute(execute => new AutomaticSmartCommand(execute, null, null));
        }
    }
}
