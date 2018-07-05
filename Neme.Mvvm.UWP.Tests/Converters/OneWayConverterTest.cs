using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI.Xaml.Data;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class OneWayConverterTest
    {
        private readonly OneWayConverterClass<string, string> converter = new OneWayConverterClass<string, string>();

        [TestMethod]
        public void TestConvert()
        {
            string calledValue = null;
            converter.ConvertImplementation = value =>
            {
                calledValue = value;
                return "convertedValue";
            };

            var result = (converter as IValueConverter).Convert("value", null, null, null);
            Assert.AreEqual("value", calledValue);
            Assert.AreEqual("convertedValue", result);
        }

        [TestMethod]
        public void ConvertBackThrows()
        {
            Assert.ThrowsException<NotSupportedException>(() => (converter as IValueConverter).ConvertBack("value", null, null, null));
        }
    }
}
