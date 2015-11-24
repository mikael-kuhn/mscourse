using System;
using GuiApplication;
using Infrastructure;
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

        public class TestMessage
        {
            public Guid Id { get; set; }
            public string Text { get; set; }

        }
        [TestMethod]
        public void TestBroker()
        {
            TestMessage message = new TestMessage {Id = Guid.NewGuid(), Text = "Some text"};
            MessageBroker broker = new MessageBroker();
            broker.Write(message);
            TestMessage readMessage = broker.Read<TestMessage>(0);
            Assert.IsNotNull(readMessage);
        }
    }
}
