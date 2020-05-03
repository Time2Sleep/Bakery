using UnityEngine;

namespace Items
{
    public class CookableGameItem : GameItem, ICookable
    {
        public GameObject cookedState;

        public void cook()
        {
            GameObject cookedObject = Instantiate(cookedState, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}