using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : LayerOnTrigger
{
    protected override void LayerTrigger(bool enter = true)
    {
        Pressed = enter;
    }

    bool pressed;
    bool Pressed
    {
        get { return pressed; }
        set
        {
            pressed = value;
            Press(value);
        }
    }

    [SerializeField] GameObject doors;

    void Press(bool pressed)
    {
        doors.SetActive(pressed);
        anim.SetBool("Pressed", pressed);
    }

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        Pressed = false;
    }
}