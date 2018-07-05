using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if WPF
using System.Windows.Controls;
#else
using Windows.UI.Xaml.Controls;
#endif

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class OrientationInverterTest
    {
        private readonly OrientationInverter converter = new OrientationInverter();

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual(Orientation.Horizontal, converter.Convert(Orientation.Vertical));
            Assert.AreEqual(Orientation.Vertical, converter.Convert(Orientation.Horizontal));

            Assert.AreEqual("value",
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => converter.Convert((Orientation)(-1))).ParamName);
        }

        [TestMethod]
        public void TestConvertBack()
        {
            Assert.AreEqual(Orientation.Horizontal, converter.ConvertBack(Orientation.Vertical));
            Assert.AreEqual(Orientation.Vertical, converter.ConvertBack(Orientation.Horizontal));

            Assert.AreEqual("value",
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => converter.ConvertBack((Orientation)(-1))).ParamName);
        }
    }
}
