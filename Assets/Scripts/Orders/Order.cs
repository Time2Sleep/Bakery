using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Order
    {
        //todo SET
        public List<OrderItem> items { get; }

        public Order(List<OrderItem> items)
        {
            this.items = items;
        }

        //debug
        public String getOrderText()
        {
            string text = "Order: ";
            foreach (OrderItem item in items)
            {
                var count = item.desiredCount > 1 ? item.desiredCount.ToString() : "";
                text += item.itemName.ToUpper() + count + " ";
            }

            return text;
        }
    }
}