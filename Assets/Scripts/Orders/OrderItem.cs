using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class OrderItem
    {
       public ItemInfo itemInfo;
        public int desiredCount { get; set; }

        public OrderItem(ItemInfo itemInfo, int desiredCount)
        {
            this.itemInfo = itemInfo;
            this.desiredCount = desiredCount;
        }
        
        
        protected bool Equals(OrderItem other)
        {
            return itemInfo.itemName.Equals(other.itemInfo.itemName);// && desiredCount == other.desiredCount;
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
                return ((itemInfo.itemName != null ? itemInfo.itemName.GetHashCode() : 0) * 397) ^ desiredCount;
            }
        }
    }
}