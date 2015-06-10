using System;
using System.IO;
using Export;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExportTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateExample()
        {
            string path = @"c:\1\example.xlsx";

            File.Delete(path);

            Excel excel = new Excel();

            excel.CreateExample(path);

            Assert.IsTrue(File.Exists(path));
        }
    }
}
