using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class NotNullConverterTest
    {
        private readonly NotNullConverter converter = new NotNullConverter();

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual(false, converter.Convert(null));
            Assert.AreEqual(true, converter.Convert(""));
            Assert.AreEqual(true, converter.Convert(1));
        }
    }
}
