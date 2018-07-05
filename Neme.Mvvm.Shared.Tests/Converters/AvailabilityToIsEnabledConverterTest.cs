using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neme.Mvvm.Commands;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class AvailabilityToIsEnabledConverterTest
    {
        private readonly AvailabilityToIsEnabledConverter converter = new AvailabilityToIsEnabledConverter();

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual(true, converter.Convert(Availability.Available));
            Assert.AreEqual(false, converter.Convert(Availability.Disabled));
            Assert.AreEqual(false, converter.Convert(Availability.Hidden));
        }
    }
}
