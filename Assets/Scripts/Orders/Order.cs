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
            string text = "";
            foreach (OrderItem item in items)
            {
                var count = item.desiredCount > 1 ? " x"+item.desiredCount : "";
                text += item.itemName.ToUpper() + count + "\n";
            }

            return text;
        }
    }
}