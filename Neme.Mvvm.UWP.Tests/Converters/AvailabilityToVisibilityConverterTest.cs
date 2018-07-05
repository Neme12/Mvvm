using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;
using Neme.Mvvm.Commands;

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
