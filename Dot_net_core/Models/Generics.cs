using System;
using System.Collections.Generic;
using System.Text;

namespace Dot_net_core.Models
{
    public class Result<T> //klasa generyczna typu ogólnego T
    {
        public T Item { get; set; }
        public bool IsValid { get; set; }
        public string Error { get; set; }
    }

    public class Pair<TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Sencond { get; set; }
    }

    public class Triple<TFirst, TSecond, TThird> : Pair<TFirst, TSecond>
    {
        public TThird Third { get; set; }
    }

    public class GenericOrderProcessor
    {
        public Result<Order> ProcessOrder(string email, int orderId)
        {
            Order order = new Order(1, 100);

            return new Result<Order>
            {
                Item = order
            };
        }
        public void LogOrder<TOrder, TSecondOrder>(TOrder order, TSecondOrder secondOrder) where TOrder : Order where TSecondOrder :Order
        {

        }
    }
    class Generics
    {
        public void Test()
        {
            GenericOrderProcessor orderProcessor = new GenericOrderProcessor();
            Result<Order> result = orderProcessor.ProcessOrder("email@gmail.com", 1);
            if(result.IsValid)
            {
                //result.Item
            }

            Pair<int, string> pair = new Pair<int, string>();
            Triple<int, string, bool> triple = new Triple<int, string, bool>();

            ReferenceResult<Order> intResult = new ReferenceResult<Order>();
            ValueREsult<int> valueREsult = new ValueREsult<int>();
            ReferenceResult<User> userResult = new ReferenceResult<User>();
        }
    }

    public class ReferenceResult<T> where T : class
    {
        public T Result { get; set; }
    }
    public class ValueREsult<T> where T : struct
    {
        public T Result { get; set; }
    }
}
