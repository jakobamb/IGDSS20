using System.Collections.Generic;
using UnityEngine;

/// <summary>Class <c>Helpers</c> provides some static utility functions.</summary>
public class Helpers
{

    /// <summary>Returns a random <c>GameObject</c> form a list. Returns <c>null</c>, if list is empty.</summary>
    public static T RandomListSelect<T>(List<T> list)
    {
        if (list.Count == 0) {
            // this will return null in most cases, 
            // using default(T) makes it safe for non-nullable types
            return default(T);
        } else {
            int idx = Random.Range(0, list.Count);
            return list[idx];
        }
    }
}