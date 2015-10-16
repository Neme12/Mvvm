using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.UI.Xaml.Data;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class BooleanInverterTest
    {
        private readonly BooleanInverter converter = new BooleanInverter();

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual(false, converter.Convert(true));
            Assert.AreEqual(true, converter.Convert(false));
        }

        [TestMethod]
        public void TestConvertBack()
        {
            Assert.AreEqual(false, converter.ConvertBack(true));
            Assert.AreEqual(true, converter.ConvertBack(false));
        }
    }
}
