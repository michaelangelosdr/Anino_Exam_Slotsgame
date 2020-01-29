using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

using System.Linq;

public class Util : MonoBehaviour
{
   public static void DebugArray(int[] arr)
   {
        StringBuilder builder = new StringBuilder();
        builder.Append("{");
        for(int x =0; x<arr.Length;x++)
        {            
            builder.Append(" " + arr[x]);            
        }
         builder.Append("}");
        Debug.Log(builder.ToString());
   }

   public static int[] GetColumn(int[,] matrix, int columnNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
                .Select(x => matrix[x, columnNumber])
                .ToArray();
    }

    public static int[] GetRow(int[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
                .Select(x => matrix[rowNumber, x])
                .ToArray();
    }
}
