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
        private bool checkSeconds = true;

        

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
            StartCoroutine(nameof(selfDestroy), 2f);
        }

        private void FixedUpdate()
        {
            if (checkSeconds)
            {
                if (secondsLeft > 0)
                {
                    secondsLeft -= 0.02f;
                    GetComponentInChildren<Slider>().value = secondsLeft / seconds;
                }
                else //Костыльный способ убрать заказ, если вышло время
                {
                    checkSeconds = false;
                    GetComponent<Image>().color = Color.red;
                    StartCoroutine(nameof(selfDestroy), 2f);
                    FindObjectOfType<Terminal>().removeOrder(this);
                }
            }
        }

        public void setTimer(float time)
        {
            seconds = time;
            secondsLeft = time;
        }

        IEnumerator selfDestroy(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}