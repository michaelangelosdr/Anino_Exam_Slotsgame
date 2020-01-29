using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Line Wins/Top Row Horizontal")]
public class TopRow_HorizontalWin : LineWin
{
    public override int[,] Line()
    {
        int[,] WinLine = {{0,0},{1,0},{2,0}};
        return WinLine;
    }

    public override int GetLineType()
    {
        return 0;
    }
}
