using Dot_net_core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dot_net_core.Tests
{
    [TestClass]
    public class OrderProcessorTests
    {
        public User user;
        public Order Order;
        public IDatabase Database;
        public IEmailSender EmailSender;
        public IOrderProcessor OrderProcessor;

        [TestInitialize]
        public void Setup()
        {
            user = new User("user@gmail.com", "secret");
            Order = new Order(10, 125);
            Database = new Database();
            EmailSender = new EmailSender();
            OrderProcessor = new OrderProcessor(Database, EmailSender);
        }

        [TestMethod]
        public void Process_order_should_succed()
        {
            //arrange
            //acct
            //OrderProcessor.ProcessOrder(user.Email, Order.Id);
            //assert
            //Assert.IsTrue(Database.isConnectet);

        }

    }
}