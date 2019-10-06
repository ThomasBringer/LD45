using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] float lifeTime = 2;

    void OnEnable()
    {
        Destroy(gameObject, lifeTime);
    }
}