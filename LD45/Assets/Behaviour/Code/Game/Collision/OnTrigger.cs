using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Trigger(collision.gameObject, true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Trigger(collision.gameObject, false);
    }

    protected abstract void Trigger(GameObject go, bool enter = true);
}