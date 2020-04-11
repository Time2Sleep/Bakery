﻿using System;
using System.Collections.Generic;


    public class Item
    {
        public string itemName { get; }
        public int count { get; set; }
        public List<GameItem> gameItemReferences { get; set; }

        public Item(GameItem gameItem)
        {
            this.itemName = gameItem.itemInfo.itemName;
            count = 1;
            gameItemReferences = new List<GameItem>();
            gameItemReferences.Add(gameItem);
        }

        public void destory(int count)
        {
            int destroyed = 0;
            foreach (GameItem gameItemReference in gameItemReferences)
            {
                if (destroyed <= count)
                {
                    gameItemReference.selfDestroy();
                    destroyed++;
                }
                else
                {
                    return;
                }
            }
        }

        public void addItemReference(GameItem gameItem)
        {
            gameItemReferences.Add(gameItem);
        }
    }