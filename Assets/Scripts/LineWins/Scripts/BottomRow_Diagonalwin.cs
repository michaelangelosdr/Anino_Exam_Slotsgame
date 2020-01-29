using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Line Wins/Bottom Diagonal Win")]
public class BottomRow_Diagonalwin : LineWin
{
    public override int[,] Line()
    {
        int[,] WinLine = {{0,2},{1,1},{2,0}};
        return WinLine;
    }
     public override int GetLineType()
    {
        return 4;
    }
}
