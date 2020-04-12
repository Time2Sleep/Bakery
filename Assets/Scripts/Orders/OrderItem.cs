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