using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if WPF
using System.Windows;
#else
using Windows.UI.Xaml;
#endif

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class VisibilitizerTest
    {
        private readonly Visibilitizer converter = new Visibilitizer();

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual(Visibility.Visible, converter.Convert(true));
            Assert.AreEqual(Visibility.Collapsed, converter.Convert(false));
        }

        [TestMethod]
        public void TestConvertBack()
        {
            Assert.AreEqual(true, converter.ConvertBack(Visibility.Visible));
            Assert.AreEqual(false, converter.ConvertBack(Visibility.Collapsed));

#if WPF
            Assert.AreEqual("value",
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => converter.ConvertBack(Visibility.Hidden)).ParamName);
#endif
            Assert.AreEqual("value",
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => converter.ConvertBack((Visibility)255)).ParamName);
        }
    }
}
