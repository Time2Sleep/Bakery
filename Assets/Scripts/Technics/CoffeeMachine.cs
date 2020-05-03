using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : Technics
{
    private bool isCooking;
    [SerializeField]private Transform pointToPlaceCoffee;
    [SerializeField] private float cookingTime = 5f;
   

    public override void interact(GameItem pickedObject)
    {
        if (isCooking)
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
