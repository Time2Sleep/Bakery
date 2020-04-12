using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalCalculator : MonoBehaviour
{
    [SerializeField] private Terminal terminal;

    private void Start()
    {
        terminal = GetComponentInParent<Terminal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameItem item = other.GetComponent<GameItem>();
        if (item != null)
        {
            terminal.addItems(new List<Item>() {item.asItem()});
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameItem item = other.GetComponent<GameItem>();
        if (item != null)
        {
            terminal.removeItem(new List<Item>() {item.asItem()});
        }
    }
}