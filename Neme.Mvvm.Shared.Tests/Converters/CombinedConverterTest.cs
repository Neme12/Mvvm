using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if WPF
using System.Windows;
using System.Windows.Data;
using ConverterLanguage = System.Globalization.CultureInfo;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using ConverterLanguage = System.String;
#endif

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class CombinedConverterTest
    {
        private readonly CombinedConverter converter;

        public CombinedConverterTest()
        {
            converter = new CombinedConverter();
            converter.Converters.Add(new BooleanInverter());
            converter.Converters.Add(new Visibilitizer());
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
            converter.Converters.Add(spy);

            var language =
#if WPF
                new ConverterLanguage("en");
#else
                "en";
#endif

            converter.Convert(true, null, null, language);
            Assert.AreEqual(language, spy.CalledLanguage);

            converter.ConvertBack(Visibility.Visible, null, null, language);
            Assert.AreEqual(language, spy.CalledLanguage);
        }

        class ValueConverterSpy : IValueConverter
        {
            public ConverterLanguage CalledLanguage { get; private set; }

            public object Convert(object value, Type targetType, object parameter, ConverterLanguage language)
            {
                CalledLanguage = language;
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, ConverterLanguage language)
            {
                CalledLanguage = language;
                return value;
            }
        }
    }
}
