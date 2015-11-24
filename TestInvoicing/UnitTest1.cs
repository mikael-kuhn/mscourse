using Gui;
using Infrastructure;
using LogIt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestInvoicing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RunFlow()
        {
            Controller controller = new Controller();
            controller.BookingReadyForInvoicing(2);

            Assert.AreEqual(4, Logger.Items.Count);
        }

        [TestMethod]
        public void TestBroker()
        {
            MessageBroker broker = new MessageBroker();
            broker.Write("test", "{ number: 1 }");
            string message = broker.Read("test", 1);
            Assert.IsNotNull(message);
        }
    }
}
