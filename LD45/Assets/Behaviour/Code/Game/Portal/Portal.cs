using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : PlayerOnTrigger
{
    Portals portals;

    void Awake()
    {
        portals = GetComponentInParent<Portals>();
    }

    protected override void PlayerTrigger(bool enter = true)
    {
        if (enter)
        {
            if (teleporting)
                teleporting = false;
            else
                portals.OnPortal(this);
        }
    }

    bool teleporting = false;

    public void TeleportTo()
    {
        teleporting = true;
        StartCoroutine(Player.movement.Teleport(transform.position));
    }
}