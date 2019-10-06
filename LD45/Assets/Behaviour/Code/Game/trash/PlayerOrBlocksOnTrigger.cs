using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerOrBlocksOnTrigger : OnTrigger
{
    protected override void Trigger(GameObject go, bool enter = true)
    {
        /*if (go.layer==layers)*/ PlayerTrigger(enter);
    }

    protected abstract void PlayerTrigger(bool enter = true);
}