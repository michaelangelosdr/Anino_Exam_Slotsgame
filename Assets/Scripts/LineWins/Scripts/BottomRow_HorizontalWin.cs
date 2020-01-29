using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Line Wins/Bottom Row Horizontal")]
public class BottomRow_HorizontalWin : LineWin
{
        public override int[,] Line()
    {
        int[,] WinLine = {{0,2},{1,2},{2,2}};
        return WinLine;
    }
     public override int GetLineType()
    {
        return 2;
    }
}
