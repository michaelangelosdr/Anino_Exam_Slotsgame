using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Line Wins/Top Diagonal Win")]
public class TopRow_DiagonalWin : LineWin
{
    public override int[,] Line()
    {
        int[,] WinLine = {{0,0},{1,1},{2,2}};
        return WinLine;
    }
     public override int GetLineType()
    {
        return 3;
    }
}
