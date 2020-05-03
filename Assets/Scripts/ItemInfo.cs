using System;
using UnityEngine;
using Object = System.Object;

[CreateAssetMenu(fileName = "Items", menuName = "DB/Items", order = 1)]
    public class ItemInfo : ScriptableObject
    {
        public String itemName;
        public GameObject itemPrefab;
        public Sprite sprite;
    }