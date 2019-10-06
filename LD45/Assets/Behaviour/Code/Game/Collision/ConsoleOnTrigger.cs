using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleOnTrigger : PlayerOnTrigger
{
    [SerializeField]string text;

    protected override void PlayerTrigger(bool enter = true)
    {
        UIManager.ui.Console(enter, text);
    }
}