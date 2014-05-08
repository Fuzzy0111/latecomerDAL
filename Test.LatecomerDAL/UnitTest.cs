using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using latecomerDAL;
using latecomerDAL.Helper;
using Core;

namespace Test.LatecomerDAL
{
    [TestFixture]
    public class UnitTest
    {
        private ReadAFile XMLFile1;
        private ReadAFile FaultyFile1;

        [TestFixtureSetUp]
        public void TestFixtureSetupMethod()
        {
            XMLFile1 = new ReadAFile(@"c:\LatecomerDocument.XML");
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDownMethod()
        {
            XMLFile1 = null;
        }

        [Test]
        public void TestReadFileXML_1of4_ShouldReturn4Latecomer()
        {
            List<Latecomer> myList = XMLFile1.ReadXMLFile();
            Assert.AreEqual(4, myList.Count);
        }

        //[Test, Exception]
        //public void TestReadFileXML_2of4_ShouldBeCaughtInException()
        //{

        //}
    }
}
