using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] float time = .1f;

    void OnEnable()
    {
        Tile[] tiles = GetComponentsInChildren<Tile>();

        foreach (var tile in tiles) tile.gameObject.SetActive(false);

        StartCoroutine(Spawn(tiles));
    }

    IEnumerator Spawn(Tile[] tiles)
    {
        foreach (var tile in tiles)
        {
            yield return new WaitForSeconds(time);

            tile.gameObject.SetActive(true);
        }
    }
}