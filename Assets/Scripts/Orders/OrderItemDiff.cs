using UnityEngine;

namespace DefaultNamespace
{
    public class OrderItemDiff
    {
        public string itemName { get; }
        public int cout { get; }
        public bool isTerminal { get; }
        public bool isValid { get; }

        public OrderItemDiff(Item item, OrderItem orderItem)
        {
            if (item == null || orderItem == null)
            {
                Debug.Log("order diff failed");
                isValid = false;
            }
            else
            {
                itemName = item.itemName;
                cout = orderItem.desiredCount;
                int countLeft = item.count - orderItem.desiredCount;
                Debug.Log("countLeft" + countLeft);
                isValid = !(countLeft < 0);
                isTerminal = countLeft == 0;
                Debug.Log("order diff ok");
            }
        }
    }
}