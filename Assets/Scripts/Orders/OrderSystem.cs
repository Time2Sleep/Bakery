using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace DefaultNamespace
{
    public class OrderSystem : MonoBehaviour
    {
        [SerializeField] private Terminal terminal;
        [SerializeField] private long timeBetweenOrders;
        [SerializeField] private int maxItemsInOrder = 1;

        //debug
        [SerializeField] private Transform canvas;
        [SerializeField] private GameObject orderPrefab;
        [SerializeField] private ItemInfo[] possibleItems;

        private void Start()
        {
            createOrder();
        }

        private void createOrder()
        {
            orderPrefab = Instantiate(orderPrefab, Vector3.zero, Quaternion.identity);
            orderPrefab.transform.SetParent(canvas.transform);
            Order order = generateRandomOrder();
            orderPrefab.GetComponentInChildren<Text>().text = order.getOrderText();
            Customer customer = orderPrefab.AddComponent<Customer>();
            customer.order = order;
            terminal.addCustomer(customer);
        }

        private Order generateRandomOrder()
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            Random random = new Random();
            for (int i = 0; i < random.Next(1, maxItemsInOrder+1); i++)
            {
                int itemId = random.Next(possibleItems.Length);
                ItemInfo itemInfo = possibleItems[itemId];
                OrderItem orderItem = new OrderItem(itemInfo.itemName, 1);
                orderItems.Add(orderItem);
                Debug.Log("Added " + orderItem.itemName + " to order");
            }
            Order order = new Order(orderItems);
            return order;
        }
    }
}