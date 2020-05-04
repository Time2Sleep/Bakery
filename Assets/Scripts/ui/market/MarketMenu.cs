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

    public override void focus()
    {
        base.focus();
        enableCharacterControls = false;
        //имхо хуита
        Invoke("returnCharControls", 0.5f);
    }

    private void returnCharControls()
    {
        enableCharacterControls = true;
    }
}