using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class Oven : Technics
{
    public override void interact(GameItem pickedObject)
    {
        if (pickedObject is ICookable cookable)
        {
            cookable.cook();
            _animation.Play("CloseC");
        }
    }
}