using System;

namespace DefaultNamespace
{
    public class OrderItem
    {
        public string itemName { get; set; }
        public int desiredCount { get; set; }

        public OrderItem(string itemName, int desiredCount)
        {
            this.itemName = itemName;
            this.desiredCount = desiredCount;
        }
    }
}