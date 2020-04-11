using UnityEngine;

namespace DefaultNamespace
{
    public class Customer : MonoBehaviour
    {
        private int secondToWaitForOrder;
        public int secondsLeft { get; }
        public Order order { get; set; }

        public void completeOrder()
        {
            Destroy(gameObject);
        }
    }
}