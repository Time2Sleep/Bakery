using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Order
    {
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
                Debug.Log(item.itemName);
                text += item.itemName.ToString().ToUpper() + " ";
            }

            return text;
        }
    }
}