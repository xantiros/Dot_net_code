using Dot_net_core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dot_net_core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public User user;

        [TestInitialize]
        public void Setup()
        {
            user = new User("user@gmail.com", "secret");
        }
        [TestMethod]
        public void TestMethod1()
        {
            //var user = new User();

        }
        [TestMethod]
        public void TestEmail()
        {
            //arrange
            var expectedEmail = "user2@gmail.com";
            //var user = new User("user@gmail.com", "secret");
            //acct
            user.SetEmail(expectedEmail);
            //assert
            Assert.AreEqual(user.Email, expectedEmail);
        }

        [TestMethod]
        public void providing_empty_password_should_faill()
        {
            //arrange
            //var user = new User("user@gmail.com", "secret");
            //acct
            var exception = Assert.ThrowsException<Exception>(() => user.SetPassword(string.Empty));
            //assert
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Equals("Password is incorrect."));
        }
    }
}