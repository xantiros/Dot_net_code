using Dot_net_core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dot_net_core.Tests
{
    [TestClass]
    public class DatebaseTest
    {
        public User user;
        public IDatabase Database;

        [TestInitialize]
        public void Setup()
        {
            user = new User("user@gmail.com", "secret");
            Database = new Database();
        }
        [TestMethod]
        public void Invoiking_connect_should_set_is_connected_to_true()
        {
            //arrange
            //acct
            Database.Connect();
            //assert
            Assert.IsTrue(Database.isConnectet);

        }
    }
}