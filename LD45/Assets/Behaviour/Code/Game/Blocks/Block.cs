using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool Pushable(Vector2 direction)
    {
        //if (position == Vector2.zero) return false;
        Vector2 position = (Vector2)transform.position + direction;

        Collider2D[] hit = Physics2D.OverlapPointAll(position, Layers.layers.world/* | Layers.layers.blocks*/);

        if (hit.Length < 1) return false;

        foreach (var collider in hit) if (!collider.isTrigger) return false;


        //print("block hit?");
        Collider2D[] blockHit = Physics2D.OverlapPointAll(position, Layers.layers.blocks);



        //foreach (var blo in blockHit)
        //{
        //    print("blo" + blo + " pos " + blo.transform.position);
        //}

        if (blockHit.Length < 1) return true;

        foreach (var collider in blockHit) if (collider.transform.parent != transform.parent) /*{ print("fsdc " + position + " " + transform.position + " " + direction+" col "+collider+ " col go "+ collider.gameObject+" col par "+ collider.transform.parent+" self par "+ transform.parent);*/ return false; //}


        return true;
    }
}