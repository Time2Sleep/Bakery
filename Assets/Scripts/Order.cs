using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Order
    {
        public List<OrderItem> items { get; }
        public int secondsToWait { get; }
        public Customer customer;

        private DateTime orderPlacedTime;

        public Order(List<OrderItem> items, Customer customer)
        {
            orderPlacedTime = DateTime.Now;
            this.customer = customer;
        }
    }
}