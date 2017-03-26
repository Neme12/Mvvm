using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class CombinedConverterTest
    {
        private readonly CombinedConverter converter;

        public CombinedConverterTest()
        {
            converter = new CombinedConverter();
            converter.Add(new BooleanInverter());
            converter.Add(new Visibilitizer());
        }

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual(Visibility.Collapsed, converter.Convert(true, null, null, null));
            Assert.AreEqual(Visibility.Visible, converter.Convert(false, null, null, null));
        }

        [TestMethod]
        public void TestConvertBack()
        {
            Assert.AreEqual(false, converter.ConvertBack(Visibility.Visible, null, null, null));
            Assert.AreEqual(true, converter.ConvertBack(Visibility.Collapsed, null, null, null));
        }

        [TestMethod]
        public void TestPassedLanguage()
        {
            var spy = new ValueConverterSpy();
            converter.Add(spy);

            converter.Convert(true, null, null, "language");
            Assert.AreEqual("language", spy.CalledLanguage);

            converter.ConvertBack(Visibility.Visible, null, null, "language");
            Assert.AreEqual("language", spy.CalledLanguage);
        }

        class ValueConverterSpy : IValueConverter
        {
            public string CalledLanguage { get; private set; }

            public object Convert(object value, Type targetType, object parameter, string language)
            {
                CalledLanguage = language;
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                CalledLanguage = language;
                return value;
            }
        }
    }
}
