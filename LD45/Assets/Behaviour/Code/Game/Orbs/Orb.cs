using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : PlayerOnTrigger
{
    [SerializeField] GameObject effect;

    protected override void PlayerTrigger(bool enter = true)
    {
        if (enter)
        {
            //Debug.Log("orb collected!");
            gameObject.SetActive(false);

            Instantiate(effect, transform.position, Quaternion.identity);

            Levels.Level++;
        }


        //throw new System.NotImplementedException();
    }
}