using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class MultiplierTest
    {
        private readonly Multiplier converter = new Multiplier { Factor = 2 };

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual(6, converter.Convert(3));
        }

        [TestMethod]
        public void TestConvertBack()
        {
            Assert.AreEqual(1.5, converter.ConvertBack(3));
        }
    }
}
