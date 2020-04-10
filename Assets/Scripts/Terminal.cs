using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;


public class Terminal : MonoBehaviour
{
    public List<Customer> customersList { get; }
    public Dictionary<String, Item> actualItems { get; }

    public Terminal()
    {
        customersList = new List<Customer>();
        actualItems = new Dictionary<string, Item>();
    }

    public void addItems(List<Item> items)
    {
        items.ForEach(item => { actualItems.Add(item.itemName, item); });
    }

    public void getItems(List<Item> items)
    {
        items.ForEach(item =>
        {
            Item placedItem = actualItems[item.itemName];
            int itemsLeft = placedItem.cout - item.cout;
            if (itemsLeft < 0)
            {
                throw new Exception("There are not enough items to remove" + item.itemName);
            }

            if (itemsLeft == 0)
            {
                actualItems[item.itemName] = null;
            }

            placedItem.cout -= item.cout;
        });
    }


    public void addCustomer(Customer customer)
    {
        customersList.Add(customer);
    }
}