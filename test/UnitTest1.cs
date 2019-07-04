using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios;
namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange

            double uf;
            Servicios.Service1 WS = new Servicios.Service1();
            //act
            uf = WS.Uf();
            Console.WriteLine(" " + uf);
            //assert
            Console.WriteLine(" " + uf);
            Assert.AreEqual(WS.Uf(), uf);
            Console.WriteLine(" "+uf);

        }
    }
}
