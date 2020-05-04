using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : Technics
{
    private bool isCooking;
    [SerializeField]private Transform pointToPlaceCoffee;
    [SerializeField] private float cookingTime = 5f;
    private InsideObjectsProvider _insideObjectsProvider;
    
    public override void Start()
    {
        base.Start();
        _insideObjectsProvider = GetComponentInChildren<InsideObjectsProvider>();
    }

    public override void interact(GameItem pickedObject)
    {
        if (isCooking || _insideObjectsProvider.items.Count>0)
        {
            return;
        }

        isCooking = true;
        _animation.Play("Cooking");
        Invoke("finishCooking", cookingTime);
    }
    
    private void finishCooking()
    {
        _animation.Play("Idle");
        Instantiate(Resources.Load("prefabs/Coffee") as GameObject, pointToPlaceCoffee.position, pointToPlaceCoffee.rotation);
        isCooking = false;
    }
}
