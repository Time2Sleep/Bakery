using System;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    private bool isMouseOver = false;
    public ItemInfo itemInfo;


    void OnMouseOver()
    {
        if (!isMouseOver)
        {
            isMouseOver = true;
            transform.localScale *= 1.1f;
        }
    }

    void OnMouseExit()
    {
        isMouseOver = false;
        transform.localScale /= 1.1f;
    }

    public void selfDestroy()
    {
        Destroy(gameObject);
    }

    public Item asItem()
    {
        return new Item(this);
    }
}