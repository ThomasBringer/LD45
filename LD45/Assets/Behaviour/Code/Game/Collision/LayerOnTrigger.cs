using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LayerOnTrigger : OnTrigger
{
    public LayerMask layer;

    protected override void Trigger(GameObject go, bool enter = true)
    {
        if (go.layer.InMask(layer))/*(go.layer==layer)*/ LayerTrigger(enter);
    }

    protected abstract void LayerTrigger(bool enter = true);
}