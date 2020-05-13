using System.Collections.Generic;
using UnityEngine;

/// <summary>Class <c>Helpers</c> provides some static utility functions.</summary>
public class Helpers
{

    /// <summary>Returns a random <c>GameObject</c> form a list. Returns <c>null</c>, if list is empty.</summary>
    public static GameObject randomListSelect(List<GameObject> list)
    {
        if (list.Count == 0) {
            return null;
        } else {
            int idx = Random.Range(0, list.Count);
            return list[idx];
        }
    }
}