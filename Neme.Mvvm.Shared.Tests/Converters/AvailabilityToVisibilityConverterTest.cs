using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neme.Mvvm.Commands;
#if WPF
using System.Windows;
#else
using Windows.UI.Xaml;
#endif

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class AvailabilityToVisibilityConverterTest
    {
        private readonly AvailabilityToVisibilityConverter converter = new AvailabilityToVisibilityConverter();

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual(Visibility.Visible, converter.Convert(Availability.Available));
            Assert.AreEqual(Visibility.Visible, converter.Convert(Availability.Disabled));
            Assert.AreEqual(Visibility.Collapsed, converter.Convert(Availability.Hidden));
        }
    }
}
