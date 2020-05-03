using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class Oven : Technics
{
    private InsideObjectsProvider _insideObjectsProvider;

    private bool isCooking;

    //only items of the same time are allowed
    private List<ICookable> itemsToCook;

    public override void Start()
    {
        base.Start();
        _insideObjectsProvider = GetComponentInChildren<InsideObjectsProvider>();
    }

    public override void interact(GameItem pickedObject)
    {
        if (isCooking)
        {
            return;
        }

        itemsToCook = new List<ICookable>();
        base.interact(pickedObject);
        _insideObjectsProvider.items.RemoveAll(item =>
        {
            if (item is ICookable cookable)
            {
                itemsToCook.Add(cookable);
                return true;
            }

            return false;
        });
        if (itemsToCook.Count > 0)
        {
            ICookable cookable = itemsToCook[0];
            _animation.Play("Cooking");
            isCooking = true;
            Invoke("finishCooking", cookable.getCookingTime());
        }
    }

    private void finishCooking()
    {
        Debug.Log("ready");
        itemsToCook.ForEach(item => item.cook());
        isOpen = true;
        _animation.Play("Open");
        isCooking = false;
    }
}