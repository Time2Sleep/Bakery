using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;


public class Terminal : MonoBehaviour
{
    public SortedSet<Customer> customersList { get; }

    public Dictionary<String, Item> actualItems { get; }

    //debug
    public int itemsOnCounter => actualItems.Count;

    public Terminal()
    {
        //создаем список отсортированный по времени отведенному заказу
        customersList = new SortedSet<Customer>(Comparer<Customer>.Create(
            (x, y) => x.secondsLeft.CompareTo(y.secondsLeft))
        );
        actualItems = new Dictionary<string, Item>();
    }

    public void addItems(List<Item> items)
    {
        items.ForEach(item => { actualItems.Add(item.itemName, item); });
        checkForCompletedOrders();
    }

    /**
     * Метод предназначен для объектов которые точно есть на терминале выдачи
     * Например, когда игрок хочет забрать который объект с терминала,
     * поэтому в случае если забрать объекты не получается, то кидаем ошибку
     *
     */
    public void removeItem(List<Item> items)
    {
        items.ForEach(item =>
        {
            actualItems.TryGetValue(item.itemName, out var placedItem);
            if (placedItem == null)
            {
                //todo remove after log fix completion
                return;
                throw new Exception("There is no such item" + item.itemName);
            }

            int itemsLeft = placedItem.count - item.count;
            if (itemsLeft < 0)
            {
                throw new Exception("There are not enough items to remove" + item.itemName);
            }

            if (itemsLeft == 0)
            {
                actualItems[item.itemName] = null;
            }

            placedItem.count -= item.count;
        });
    }

    public OrderItemDiff findItemByOrderItem(OrderItem orderItem)
    {
        actualItems.TryGetValue(orderItem.itemName, out var item);
        return new OrderItemDiff(item, orderItem);
    }

    public void addCustomer(Customer customer)
    {
        customersList.Add(customer);
        checkForCompletedOrders();
    }

    private void checkForCompletedOrders()
    {
        List<Customer> servedCustomers = new List<Customer>();
        foreach (Customer customer in customersList)
        {
            var itemDiffs = tryCompleteOrder(customer.order);
            if (itemDiffs != null)
            {
                itemDiffs.ForEach(diff =>
                {
                    if (diff.isTerminal)
                    {
                        actualItems[diff.itemName].destory(diff.count);
                        actualItems.Remove(diff.itemName);
                    }
                    else
                    {
                        var item = actualItems[diff.itemName];
                        item.count -= diff.count;
                    }
                });
                Debug.Log("customer found");
                servedCustomers.Add(customer);
            }
        }

        servedCustomers.ForEach(customer =>
        {
            Debug.Log("order completed");
            customersList.Remove(customer);
            customer.completeOrder();
        });
    }


    /**
     * Возвращаем список данные по заказу, который может быть выполнен.
     * Если на выполенение заказа не хвататет элементов возвращаем временно null 
     */
    private List<OrderItemDiff> tryCompleteOrder(Order order)
    {
        List<OrderItemDiff> checkedItems = new List<OrderItemDiff>();
        foreach (OrderItem orderItem in order.items)
        {
            Debug.Log("Checking for " + orderItem.itemName);
            var itemDiff = findItemByOrderItem(orderItem);
            if (!itemDiff.isValid)
            {
                Debug.Log("Item diff failed" + orderItem.itemName + " " + itemDiff.count);
                return null;
            }

            Debug.Log("order item found");
            checkedItems.Add(itemDiff);
        }

        return checkedItems;
    }
}