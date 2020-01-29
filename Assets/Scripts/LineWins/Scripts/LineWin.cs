using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWin : ScriptableObject
{

private int[,] WinLine;

private int LineType;
public virtual int[,] Line()
{

    return WinLine;
}

public virtual int GetLineType()
{
    return LineType;
}
   
}




