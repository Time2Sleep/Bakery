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
        public Order order { get; set; }

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