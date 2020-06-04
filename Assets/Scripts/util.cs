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

    public static List<T> GetNeighbours<T>(T[,] array2d, int i, int j)
    {
        List<T> neighbours = new List<T>();
        int row_limit = array2d.GetLength(0);
        int column_limit = array2d.GetLength(1);
        if (row_limit > 0)
            {
                for (int x = System.Math.Max(0, i-1); x <= System.Math.Min(i+1, row_limit); x++)
                {
                    for (int y = System.Math.Max(0, j-1); y <= System.Math.Min(j+1, column_limit); y++)
                    {
                        if (x != i || y != j)
                        {
                            neighbours.Add(array2d[x, y]);
                        }
                }
            }
        }
        return neighbours;
    }
}