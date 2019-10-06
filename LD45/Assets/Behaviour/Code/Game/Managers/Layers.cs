using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layers : MonoBehaviour
{
    static public Layers layers;

    void Awake() { layers = this; }

    public LayerMask player;
    public LayerMask world;
    public LayerMask blocks;
    public LayerMask everything;
    public LayerMask cutscene;
}