using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player player;
    static public PlayerMovement movement;

    void Awake()
    {
        player = this;
        movement = GetComponent<PlayerMovement>();
    }

    static public bool IsPlayer(GameObject go) { return go == player.gameObject; }
}