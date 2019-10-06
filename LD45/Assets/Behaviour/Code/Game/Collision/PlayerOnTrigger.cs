using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerOnTrigger : OnTrigger
{
    protected override void Trigger(GameObject go, bool enter = true)
    {
        if (Player.IsPlayer(go)) PlayerTrigger(enter);
    }

    protected abstract void PlayerTrigger(bool enter = true);
}