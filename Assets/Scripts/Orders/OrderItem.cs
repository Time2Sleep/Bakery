using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class OrderItem
    {
        public string itemName { get; set; }
        public Sprite sprite{ get; }
        public int desiredCount { get; set; }

        public OrderItem(ItemInfo itemInfo, int desiredCount)
        {
            this.itemName = itemInfo.itemName;
            this.sprite = itemInfo.sprite;
            this.desiredCount = desiredCount;
        }
        
        
        protected bool Equals(OrderItem other)
        {
            return itemName == other.itemName && desiredCount == other.desiredCount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((itemName != null ? itemName.GetHashCode() : 0) * 397) ^ desiredCount;
            }
        }
    }
}