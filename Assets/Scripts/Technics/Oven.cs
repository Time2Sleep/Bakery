using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class Oven : Technics
{
    private InsideObjectsProvider _insideObjectsProvider;

    public override void Start()
    {
        base.Start();
        _insideObjectsProvider = GetComponentInChildren<InsideObjectsProvider>();
    }

    public override void interact(GameItem pickedObject)
    {
        base.interact(pickedObject);
        _insideObjectsProvider.items.RemoveAll(item =>
        {
            if (item is ICookable cookable)
            {
                cookable.cook();
                return true;
            }

            return false;
        });
    }
}