using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatOrb : PlayerOnTrigger
{
    [SerializeField] GameObject effect;

    protected override void PlayerTrigger(bool enter = true)
    {
        if (enter)
        {
            //Debug.Log("orb collected!");
            gameObject.SetActive(false);

            Instantiate(effect, transform.position, Quaternion.identity);

            TimelineManager.tm.EndGame();
        }
    }
}