using System;
using UnityEngine;
using UnityEngine.UI;

public class MarketMenu : UiMenu
{
    public ItemInfo[] soldItems;
    public GameObject marketItemPrefab;

    private void Start()
    {
        populateMarket();
    }

    private void populateMarket()
    {
        foreach (ItemInfo soldItem in soldItems)
        {
            GameObject gameObject = Instantiate(marketItemPrefab, canvasObjects[0].transform, false);
            gameObject.GetComponent<MarketButton>().itemInfo = soldItem;
            Text text = gameObject.GetComponentInChildren<Text>();
            text.text = soldItem.itemName + " " + soldItem.price + "$";
        }
    }
}