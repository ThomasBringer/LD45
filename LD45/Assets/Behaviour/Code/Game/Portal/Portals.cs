using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    [SerializeField] Portal[] portals;
       
    void TeleportTo(int portal)
    {
        portals[portal].TeleportTo();
    }

    public void OnPortal(Portal portal)
    {
        TeleportTo((PortalToIndex(portal) + 1) % portals.Length);
    }

    int PortalToIndex(Portal portal)
    {
        for (int i = 0; i < portals.Length; i++)
            if (portals[i] == portal) return i;

        return 0;
    }
}