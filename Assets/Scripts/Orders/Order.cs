using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Order
    {
        //todo SET
        public List<OrderItem> items { get; }

        public Order(List<OrderItem> items)
        {
            this.items = items;
        }

        //debug
        public String getOrderText()
        {
            string text = "";
            foreach (OrderItem item in items)
            {
                var count = item.desiredCount > 1 ? " x"+item.desiredCount : "";
                text += item.itemInfo.itemName.ToUpper() + count + "\n";
            }

            return text;
        }

        public void setIcons(Transform parent)
        {
            Debug.Log(Resources.Load("prefabs/iconPrefab"));
            foreach (OrderItem item in items)
            {
                string text = item.desiredCount > 1 ? "x"+item.desiredCount : "";
                GameObject icon = GameObject.Instantiate(Resources.Load("prefabs/iconPrefab") as GameObject);
                icon.GetComponentInChildren<Text>().text = text;
                icon.GetComponent<Image>().sprite = item.itemInfo.sprite;
                icon.transform.SetParent(parent);
            }
        }
    }
}