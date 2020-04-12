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
        //создаем список отсортированный по времени отведенному заказу
        customersList = new List<Customer>();
        actualItems = new Dictionary<string, Item>();
    }

    public void addItems(List<Item> items)
    {
        items.ForEach(item =>
        {
            actualItems.TryGetValue(item.itemName, out var presentItem);
            if (presentItem != null)
            {
                presentItem.count += item.count;
                presentItem.addItemReference(item.gameItemReferences[0]);
            }
            else
            {
                actualItems.Add(item.itemName, item);
            }
        });
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
                actualItems.Remove(item.itemName);
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
                foreach (OrderItemDiff itemDiff in itemDiffs)
                {
                    if (itemDiff.isTerminal)
                    {
                        Debug.LogFormat("removing item. Name {0}, count {1}", itemDiff.itemName, itemDiff.count);
                        actualItems.TryGetValue(itemDiff.itemName, out var itemToDelete);
                        if (itemToDelete == null)
                        {
                            Debug.Log("wtf");
                            return;
                        }

                        itemToDelete.destory(itemDiff.count);
                        actualItems.Remove(itemDiff.itemName);
                    }
                    else
                    {
                        var item = actualItems[itemDiff.itemName];
                        item.count -= itemDiff.count;
                    }
                }

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