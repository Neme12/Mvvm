using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Commands.Tests
{
    [TestClass]
    public class SmartCommandNotifierTest
    {
        [TestMethod]
        public void TestAvailabilityChanged()
        {
            var command = new SmartCommandClass();
            command.RaiseAvailabilityChanged();

            bool propertyChangedCalled = false;
            command.PropertyChanged += (sender, e) =>
            {
                Assert.AreEqual(command, sender);
                Assert.AreEqual(nameof(ISmartCommand.Availability), e.PropertyName);
                propertyChangedCalled = true;
            };

            Assert.IsFalse(propertyChangedCalled);
            command.RaiseAvailabilityChanged();
            Assert.IsTrue(propertyChangedCalled);
        }

        class SmartCommandClass : SmartCommandNotifier
        {
            public void RaiseAvailabilityChanged()
            {
                AvailabilityChanged?.Invoke(this, EventArgs.Empty);
            }

            public override void Execute()
            {
                throw new NotImplementedException();
            }

            public override event EventHandler AvailabilityChanged;
        }
    }
}
