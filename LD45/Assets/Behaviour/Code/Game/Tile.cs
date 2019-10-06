using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject backEffect;
    [SerializeField] GameObject endEffect;

    [SerializeField] float scaleMultiplier = 1;

    void OnEnable()
    {
        Effect(backEffect);

        //Instantiate(effect, transform.position, Quaternion.identity).transform.localScale = transform.localScale;
    }

    void OnDisable()
    {
        Effect(endEffect);
    }

    void Effect(GameObject effect)
    {
        GameObject instance = Instantiate(effect, transform.position, Quaternion.identity);
        instance.transform.localScale = transform.localScale * scaleMultiplier;
        instance.layer = gameObject.layer;
    }
}