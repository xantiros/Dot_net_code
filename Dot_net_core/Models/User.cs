using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dot_net_core.Models
{
    public class User
    {
        private ISet<Order> _orders = new HashSet<Order>(); //Set - zbiór niepowtarzajacych sie elementów

        //[Required] //atrybut //atrybuty sa klasami
        //[EmailAddress]
        public string Email { get; private set; }

        [UserPassword(length: 6)]
        public string Password { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime UpdateAt { get; private set; }

        public decimal Funds { get; private set; }

        public IEnumerable<Order> Orders { get { return _orders; } } //interfejs który udostępnia operacje enumeracji

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email)) //email jest null or white space
            {
                throw new Exception("Email is incorrect.");
            }
            if(Email == email) //stary email == nowy
            {
                return;
            }
            Email = email;
            Update();
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) 
            {
                throw new Exception("Password is incorrect.");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            Update();
        }

        public void SetAge(int age)
        {
            if(age < 13)
            {
                throw new Exception("Age mus be greater or equal to 13");
            }
            if(Age == age)
            {
                return;
            }
            Age = age;
            Update();
        }

        public void Activate()
        {
            if(IsActive)
            {
                return;
            }
            IsActive = true;
            Update();
        }

        public void Deactivate()
        {
            if (!IsActive)
            {
                return;
            }
            IsActive = false;
            Update();
        }

        public void IncreaseFunds(decimal funds)
        {
            if(funds <=0)
            {
                throw new Exception("Funds mus be greater than 0.");
            }
            Funds += funds;
            Update();
        }

        public void PurchaseOrder(Order order)
        {
            if(!IsActive)
            {
                throw new Exception("Only active user can purchase an order.");
            }

            decimal orderPrice = order.TotalPrice;

            if (Funds - orderPrice < 0)
            {
                throw new Exception("You don't have anough money");
            }

            order.Purchase();
            Funds -= orderPrice;
            _orders.Add(order);
            Update();
        }

        private void Update()
        {
            UpdateAt = DateTime.UtcNow;
        }

    }
}
