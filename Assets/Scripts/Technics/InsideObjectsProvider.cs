using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class InsideObjectsProvider : MonoBehaviour
{
    public List<GameItem> items
    {
        //todo remove from getter
        get { return calculateObjectsInside(); }
    }

    private List<GameItem> calculateObjectsInside()
    {
        List<GameItem> items = new List<GameItem>();
        var colliders = Physics.OverlapBox(transform.position, transform.lossyScale / 2);
        foreach (var collider in colliders)
        {
            GameItem item = collider.GetComponent<GameItem>();
            if (item != null)
            {
                items.Add(item);
            }
        }

        return items;
    }
}