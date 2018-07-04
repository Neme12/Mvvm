using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class StringNotEmptyConverterTest
    {
        private readonly StringNotEmptyConverter converter = new StringNotEmptyConverter();

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual("value", Assert.ThrowsException<ArgumentNullException>(() => converter.Convert(null)).ParamName);
            Assert.AreEqual(false, converter.Convert(""));
            Assert.AreEqual(true, converter.Convert("hello"));
        }
    }
}
