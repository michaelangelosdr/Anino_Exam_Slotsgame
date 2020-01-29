using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Line Wins/Middle Row Horizontal")]
public class MiddleRow_HorizontalWin : LineWin
{
        public override int[,] Line()
    {
        int[,] WinLine = {{0,1},{1,1},{2,1}};
        return WinLine;
    }

     public override int GetLineType()
    {
        return 1;
    }
   
}
