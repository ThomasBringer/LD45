using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    //Block[] blocks;

    public bool Pushable(Vector2 direction)
    {
        // = GetComponentsInChildren<Block>();

        foreach (var block in GetComponentsInChildren<Block>()) if (!block.Pushable(direction)) return false;

        return true;
    }

    //void TryPush(Vector2 direction)
    //{
    //    if (Pushable(direction)) Push(direction);
    //}

    public void Push(Vector2 direction)
    {
        //print("push");

        target += direction;
    }

    [SerializeField] float time = 1;

    Vector2 target;
    Vector2 vel;

    void OnEnable()
    {
        target = transform.position;

        //blocks = GetComponentsInChildren<Block>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.SmoothDamp(transform.position, target, ref vel, time);
    }
}