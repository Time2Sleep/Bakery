using System;
using System.Collections.Generic;
using UnityEngine;

public class InsideObjectsProvider : MonoBehaviour
{
    public List<GameItem> items { get; set; }

    private void Start()
    {
        items = new List<GameItem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.GetComponent<GameItem>() is GameItem gameItem)
        {
            items.Add(gameItem);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.GetComponent<GameItem>() is GameItem gameItem)
        {
            items.Remove(gameItem);
        }
    }
}