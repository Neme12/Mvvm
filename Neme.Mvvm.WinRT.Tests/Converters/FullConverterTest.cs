using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.UI.Xaml.Data;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class FullConverterTest
    {
        private readonly FullConverterClass<string, string> converter = new FullConverterClass<string, string>();

        [TestMethod]
        public void TestConvert()
        {
            string calledValue = null;
            converter.ConvertImplementation = value => {
                calledValue = value;
                return "convertedValue";
            };

            var result = (converter as IValueConverter).Convert("value", null, null, null);
            Assert.AreEqual("value", calledValue);
            Assert.AreEqual("convertedValue", result);
        }

        [TestMethod]
        public void TestConvertBack()
        {
            string calledValue = null;
            converter.ConvertBackImplementation = value => {
                calledValue = value;
                return "convertedValue";
            };

            var result = (converter as IValueConverter).ConvertBack("value", null, null, null);
            Assert.AreEqual("value", calledValue);
            Assert.AreEqual("convertedValue", result);
        }
    }
}
