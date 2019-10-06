using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float time = 1;

    Vector2 target;
    Vector2 vel;

    static public bool controllable = true;

    void Update()
    {
        if (!controllable) return;

        TryMove(CheckInput());
        Move();
    }

    Vector2 CheckInput()
    {
        if (Moving) return Vector2.zero;

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 movement;

        if (input.x == 0) return Vector2.zero;

        movement = Vector2.up * input.y * .75f;

        movement += Vector2.right * input.x * (input.y == 0 ? 1 : .5f);

        return movement;
        // movement=Vector2.x*input.x

        //switch (input.y)
        //{
        //    case 1:
        //    case -1:

        //        switch (input.x)
        //        {
        //            case 1:
        //        }

        //        break;
        //}
    }

    void TryMove(Vector2 offset)
    {
        if (Moving || offset == Vector2.zero) return;

        Vector2 futureTarget = target + offset;

        if (CanMove(futureTarget))
        { target = futureTarget; Animate(offset); }
    }

    SpriteRenderer rdr;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;
    [SerializeField] Sprite rightSprite;

    Animator anim;

    void Animate(Vector2 offset)
    {
        transform.localScale = new Vector2(-Mathf.Sign(offset.x), 1);

        Sprite sprite = rightSprite;

        //if (offset.y == 0) sprite = rightSprite;
        if (offset.y > 0) sprite = frontSprite;
        else if (offset.y < 0) sprite = backSprite;

        rdr.sprite = sprite;

        anim.SetTrigger("Jump");
    }

    bool CanMove(Vector2 position)
    {
        //if (position == Vector2.zero) return false;
        //print("canmove");

        Collider2D[] hit = Physics2D.OverlapPointAll(position, Layers.layers.world);

        if (hit.Length < 1) return false;

        foreach (var collider in hit) if (!collider.isTrigger) return false;


        Collider2D blockHit = Physics2D.OverlapPoint(position, Layers.layers.blocks);

        if (blockHit == null) return true;

        Vector2 direction = position - (Vector2)transform.position;
        Blocks blocks = blockHit.GetComponentInParent<Blocks>();

        bool pushable = blocks.Pushable(direction);

        if (pushable) blocks.Push(direction);

        //print("pushable " + pushable);

        //print("pushable " + pushable);

        return pushable;

        //blockHit.GetComponentInParent<Blocks>().Push(direction);
        //if (!blockHit.GetComponentInParent<Blocks>().Pushable(direction)) return false;

        //blockHit.GetComponentInParent<Blocks>().Push(direction);



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

    void Move()
    {
        transform.position = Vector2.SmoothDamp(transform.position, target, ref vel, time);
    }

    //bool Moving { get { return target != (Vector2)transform.position; } }
    bool Moving { get { return !target.Approximate(transform.position); } }

    Collider2D cldr;

    void Awake()
    {
        cldr = GetComponent<Collider2D>();
        rdr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    public IEnumerator Teleport(Vector2 position)
    {
        cldr.enabled = false;

        target = position;
        yield return new WaitWhile(() => Moving);

        cldr.enabled = true;
    }
}