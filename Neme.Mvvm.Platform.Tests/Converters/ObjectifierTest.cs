using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Converters.Tests
{
    [TestClass]
    public class ObjectifierTest
    {
        private readonly Objectifier converter = new Objectifier();

        [TestMethod]
        public void TestConvert()
        {
            Assert.AreEqual(1, converter.Convert(1));
            Assert.AreEqual("hello", converter.Convert("hello"));
        }

        [TestMethod]
        public void TestConvertBack()
        {
            Assert.AreEqual(1, converter.ConvertBack(1));
            Assert.AreEqual("hello", converter.ConvertBack("hello"));
        }
    }
}
