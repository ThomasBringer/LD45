using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ExtensionMethods
{
    public static GameObject[] GetAllChildren(this GameObject go)
    {
        var children = new List<GameObject>();
        Transform[] transforms = go.GetComponentsInChildren<Transform>();
        foreach (var trans in transforms) children.Add(trans.gameObject);
        return children.ToArray();
    }

    public static T RandomItem<T>(this T[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static bool Approximate(this float a, float b)
    {
        return Mathf.Abs(a - b) <= Utilities.ApproximateComparisonNumber;
    }

    public static bool Approximate(this Vector2 a, Vector2 b)
    {
        return a.x.Approximate(b.x) && a.y.Approximate(b.y);
    }

    public static void SetLayer(this GameObject go, string layer)
    {
        go.layer = LayerMask.NameToLayer(layer);
    }

    public static void ApplyDrag(this Rigidbody2D rb, Vector2 axis, float drag = 1)
    {
        float amount = 1 - Time.fixedDeltaTime * drag;
        rb.velocity = Vector2.Scale(rb.velocity, new Vector2(axis.x == 0 ? 1 : amount, axis.y == 0 ? 1 : amount));
    }

    public static void ApplyHorizontalDrag(this Rigidbody2D rb, float drag = 1)
    {
        rb.ApplyDrag(Vector2.right, drag);
    }

    public static bool Probability(this float prob)
    {
        return UnityEngine.Random.Range(0f, 1f) <= prob;
    }

    public static bool InMask(this int layer, LayerMask mask)
    {
        return mask == (mask | (1 << layer));
    }

    public static string Reverse(this string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

public static class Utilities
{
    public static int NegPos { get { return UnityEngine.Random.Range(0, 2) * 2 - 1; } }

    public static GameObject[] GetAllGameObjects() { return GameObject.FindObjectsOfType<GameObject>(); }

    public static void ReloadScene() { UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); }

    public static float ApproximateComparisonNumber = .001f;
}