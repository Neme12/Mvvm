using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.UI.Xaml.Data;
using System.Windows.Input;
using Neme.Mvvm.Commands;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class SmartCommandConverterTest
    {
        private readonly SmartCommandConverter converter = new SmartCommandConverter();
        private readonly SmartCommandSpy spy;
        private readonly ICommand command;

        public SmartCommandConverterTest()
        {
            spy = new SmartCommandSpy();
            command = converter.Convert(spy);
        }

        [TestMethod]
        public void TestExecute()
        {
            Assert.IsFalse(spy.ExecuteCalled);
            command.Execute(null);
            Assert.IsTrue(spy.ExecuteCalled);
        }

        [TestMethod]
        public void TestCanExecute()
        {
            spy.Availability = Availability.Available;
            Assert.IsTrue(command.CanExecute(null));

            spy.Availability = Availability.Disabled;
            Assert.IsFalse(command.CanExecute(null));

            spy.Availability = Availability.Hidden;
            Assert.IsFalse(command.CanExecute(null));
        }

        [TestMethod]
        public void TestCanExecuteChanged()
        {
            spy.RaiseAvailabilityChanged();

            bool canExecuteCalled = false;
            command.CanExecuteChanged += (sender, e) =>
            {
                Assert.AreEqual(command, sender);
                Assert.AreEqual(EventArgs.Empty, e);
                canExecuteCalled = true;
            };

            Assert.IsFalse(canExecuteCalled);
            spy.RaiseAvailabilityChanged();
            Assert.IsTrue(canExecuteCalled);
        }

        class SmartCommandSpy : ISmartCommand
        {
            public Availability Availability { get; set; }

            public bool ExecuteCalled { get; private set; } = false;
            public void Execute()
            {
                ExecuteCalled = true;
            }

            public void RaiseAvailabilityChanged()
            {
                AvailabilityChanged?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler AvailabilityChanged;
        }
    }
}
