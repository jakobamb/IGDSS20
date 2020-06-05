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

    public static List<T> GetPentagonNeighbours<T>(T[,] array2d, int i, int j)
    {
        List<T> neighbours = new List<T>();
        int row_limit = array2d.GetLength(0) - 1;
        int column_limit = array2d.GetLength(1) - 1;

        // local function to simplify testing if numbers are inside array index range
        bool testArrayRange(int x, int y) => testRange(x, 0, row_limit) && testRange(y, 0, column_limit);

        // check all sides of the pentagon and add

        // every second row is shifted, so we need different checks
        if (i % 2 == 0)
        {
            if (testArrayRange(i - 1, j - 1)) { neighbours.Add(array2d[i - 1, j - 1]); }
            if (testArrayRange(i    , j - 1)) { neighbours.Add(array2d[i    , j - 1]); }
            if (testArrayRange(i + 1, j    )) { neighbours.Add(array2d[i + 1, j    ]); }
            if (testArrayRange(i    , j + 1)) { neighbours.Add(array2d[i    , j + 1]); }
            if (testArrayRange(i + 1, j - 1)) { neighbours.Add(array2d[i + 1, j - 1]); }
            if (testArrayRange(i - 1, j    )) { neighbours.Add(array2d[i - 1, j    ]); }


        } 
        else
        {
            if (testArrayRange(i    , j - 1)) { neighbours.Add(array2d[i    , j - 1]); }
            if (testArrayRange(i - 1, j + 1)) { neighbours.Add(array2d[i - 1, j + 1]); }
            if (testArrayRange(i + 1, j    )) { neighbours.Add(array2d[i + 1, j    ]); }
            if (testArrayRange(i + 1, j + 1)) { neighbours.Add(array2d[i + 1, j + 1]); }
            if (testArrayRange(i    , j + 1)) { neighbours.Add(array2d[i    , j + 1]); }
            if (testArrayRange(i - 1, j    )) { neighbours.Add(array2d[i - 1, j    ]); }
        }

        return neighbours;
    }

    public static bool testRange(int x, int lowerBound, int upperBound) => (x >= lowerBound && x <= upperBound);
}