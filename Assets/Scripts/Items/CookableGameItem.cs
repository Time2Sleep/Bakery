using System.Collections;
using UnityEngine;

namespace Items
{
    public class CookableGameItem : GameItem, ICookable
    {
        public GameObject cookedState;
        public float secondsToCook = 1;

        public void cook()
        {
            Instantiate(cookedState, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        public float getCookingTime()
        {
            return secondsToCook;
        }
    }
}