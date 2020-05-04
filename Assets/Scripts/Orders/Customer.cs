using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Customer : MonoBehaviour
    {
        private int secondToWaitForOrder;
        private float secondsLeft;
        private float seconds;
        private Order order;
        
        public Order Order
        {
            get { return order;}
            set
            {
                order = value;
                foreach (var ord in order.items)
                {
                    GetComponent<RectTransform>().sizeDelta += new Vector2(75f, 0f);
                }
            }
        }

        public void completeOrder()
        {
            GetComponent<Image>().color = Color.green;
            StartCoroutine("selfDestroy");
        }

        private void FixedUpdate()
        {
            if (secondsLeft > 0)
            {
                secondsLeft -= 0.02f;
                GetComponentInChildren<Slider>().value = secondsLeft/seconds;
            }
        }

        public void setTimer(float time)
        {
            seconds = time;
            secondsLeft = time;
        }

        IEnumerator selfDestroy()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}