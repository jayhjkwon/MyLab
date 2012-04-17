using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MoqTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<IService>();
            mock.Setup(x => x.DoSomething("test")).Returns(false);

            IService service = mock.Object;
            Controller client = new Controller(service);

            bool result = client.GetReult("test");
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var mock = new Mock<IService>();
            mock.Setup(x => x.DoSomething(It.IsAny<string>())).Returns(false);

            IService service = mock.Object;
            Controller client = new Controller(service);

            bool result = client.GetReult("hello");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var mock = new Mock<IService>();
            mock.Setup(x => x.DoSomething(It.Is<string>(s=>s.Length == 5))).Returns(false);

            IService service = mock.Object;
            Controller client = new Controller(service);

            bool result = client.GetReult("hello");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var mock = new Mock<IService>();

            bool check = true;
            mock.Setup(x => x.DoSomething("test"))
                .Returns(() => false)
                .Callback(()=> check = false);

            IService service = mock.Object;
            Controller client = new Controller(service);

            bool result = client.GetReult("test");

            Assert.IsFalse(result);
            Assert.IsFalse(check);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var mock = new Mock<Controller>();

            mock.Setup(x => x.Id).Returns(100);

            Assert.AreEqual(100, mock.Object.Id);
        }
    }
}
