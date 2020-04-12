using UnityEngine;

namespace Items
{
    public class CookableGameItem : GameItem, ICookable
    {
        public void cook()
        {
            Debug.Log("cooking");
        }
    }
}