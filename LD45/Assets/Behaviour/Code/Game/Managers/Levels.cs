using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    static public Levels levels;

    void Awake() { levels = this; }

    [SerializeField] GameObject[] maps;

    static int level;
    public static int Level
    {
        get { return level; }
        set
        {
            level = value;
            levels.SetLevel(value);
        }
    }

    void SetLevel(int value)
    {
        maps[value].SetActive(true);

        SoundManager.SetLevel(value);
    }
}