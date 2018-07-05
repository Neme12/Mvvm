using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class Int32NotZeroConverterTest
    {
        private readonly Int32NotZeroConverter converter = new Int32NotZeroConverter();

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual(false, converter.Convert(0));
            Assert.AreEqual(true, converter.Convert(-1));
            Assert.AreEqual(true, converter.Convert(1));
        }
    }
}
