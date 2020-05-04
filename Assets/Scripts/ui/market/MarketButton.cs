using UnityEngine;
using UnityEngine.Events;

public class MarketButton : MonoBehaviour
{
    public ItemInfo itemInfo;

    public void onClick()
    {
        GameObject gameObject = Instantiate(itemInfo.itemPrefab);
        PickAndDrop.instance.pickUpObject(gameObject);
        MainUiFrame.instance.resetToDefault();
    }
}