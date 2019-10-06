using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform toFollow;

    [SerializeField] float time = 1;

    Vector2 vel;

    void LateUpdate()
    {
        transform.position = Vector2.SmoothDamp(transform.position, toFollow.position, ref vel, time);
    }
}