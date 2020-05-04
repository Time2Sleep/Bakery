using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.UI;


public class Terminal : MonoBehaviour
{
    public List<Customer> customersList { get; }
    private int money = 0;
    [SerializeField]private Text moneyText;
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
        actualItems.TryGetValue(orderItem.itemInfo.itemName, out var item);
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
            var itemDiffs = tryCompleteOrder(customer.Order);
            if (itemDiffs != null)
            {
                foreach (OrderItemDiff itemDiff in itemDiffs)
                {
                    if (itemDiff.isTerminal)
                    {
                        actualItems.TryGetValue(itemDiff.itemName, out var itemToDelete);
                        if (itemToDelete == null)
                        {
                            return;
                        }

                        money += itemToDelete.price;
                        moneyText.text = money.ToString();
                        itemToDelete.destory(itemDiff.count);
                        actualItems.Remove(itemDiff.itemName);
                    }
                    else
                    {
                        var item = actualItems[itemDiff.itemName];
                        item.count -= itemDiff.count;
                    }
                }

                servedCustomers.Add(customer);
            }
        }

        servedCustomers.ForEach(customer =>
        {
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
            var itemDiff = findItemByOrderItem(orderItem);
            if (!itemDiff.isValid)
            {
                return null;
            }

            checkedItems.Add(itemDiff);
        }

        return checkedItems;
    }
}