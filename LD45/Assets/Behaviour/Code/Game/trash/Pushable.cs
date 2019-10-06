using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    bool CanMove(Vector2 position)
    {
        if (position == Vector2.zero) return false;

        Collider2D[] hit = Physics2D.OverlapPointAll(position, Layers.layers.world);

        if (hit.Length < 1) return false;

        foreach (var collider in hit) if (!collider.isTrigger) return false;

        return true;


        //if (position == Vector2.zero) return false;

        ////print("position: " + position);
        ////print("position: " + position + ", can move? " + Physics2D.OverlapPoint(position) != null + ", what collider?" + Physics2D.OverlapPoint(position) + ".");
        ////return Physics2D.OverlapPoint(position) != null;
        //RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, position - (Vector2)transform.position, Vector2.Distance(transform.position, position), Layers.layers.world.value);

        ////Debug.DrawRay(transform.position, position - (Vector2)transform.position);

        //Debug.Log(hit.Length);

        //if (hit.Length <= 1) return false;

        //return hit[1].collider.isTrigger;

    }
}