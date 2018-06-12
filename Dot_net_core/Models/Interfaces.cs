using System;
using System.Collections.Generic;
using System.Text;

namespace Dot_net_core.Models
{
    //interfejsy -- posiada tylko publiczne pola, po klasach bazowych mozemy dzedzicyc po jednej klasie 
    //interfejsów mozna implemntowac wiele
    //interfejs jest kontraktem który definiuje tylko publiczne metody i pola

    public interface IEmailSender
    {
        void SendMessage(string receiver, string title, string message);
    }

    public class EmailSender : IEmailSender
    {
        public void SendMessage(string receiver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDatabase
    {
        bool isConnectet { get; }

        void Connect();

        User GetUser(string email);

        Order GetOrder(int id);

        void SaveChanges();
    }

    public class Database : IDatabase
    {
        public bool isConnectet { get; protected set; }

        public void Connect()
        {
            if (isConnectet) return;

            isConnectet = true;
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

    public interface IOrderProcessor
    {
        void ProcessOrder(string email, int orderId);
    }

    public class OrderProcessor : IOrderProcessor
    {
        private readonly IDatabase _database;

        private readonly IEmailSender _emailSender;

        public OrderProcessor(IDatabase database, IEmailSender emailSender)
        {
            _database = database;
            _emailSender = emailSender;
        }

        public void ProcessOrder(string email, int orderId)
        {
            User user = _database.GetUser(email); //fetch from db
            Order order = _database.GetOrder(orderId); //fetch from db

            user.PurchaseOrder(order);
            _database.SaveChanges();
            _emailSender.SendMessage(email, "Order purchased", "You've purchased an order");

        }
    }

    public class Shop 
    {
        public void CompleteOrder()
        {
            IDatabase database = new Database();
            IEmailSender emailSender = new EmailSender();
            IOrderProcessor orderProcessor = new OrderProcessor(database, emailSender); //nowa instancja, operujemy na typie interfejsu
        }
    }

}
