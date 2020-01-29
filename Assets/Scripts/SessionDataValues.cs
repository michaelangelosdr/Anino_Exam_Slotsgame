using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionDataValues
{
    public SlotSymbol[,] ReelDatasets;

    public int[,] ReelLineMatrix = new int[3,3];

    public Slot[] SlotLineMatrix = new Slot[9];
    //Reel Line matrix should be the 3x3 collections
    //of symbols
    public float SpinTimeAnimation= 1;

    public List<LineWin> WinningLines = new List<LineWin>();
    public int TotalAmountWon;

    public int TotalBet=1;

    public void RefreshWinnings()
    {
        TotalAmountWon = 0;
        WinningLines.Clear();
    }
    public void UpdateMatrix(int[] symbolOffset)
    {
         for(int row = 0; row<ReelDatasets.GetLength(0);row++)
        { 
        int offset =0;
            for(int col =0; col<ReelLineMatrix.GetLength(1);col++)
            {    
                ReelLineMatrix[row,col] = 
                (int)ReelDatasets[row,symbolOffset[row]+offset++].ID; 
            }
        }         
    }
    

}

public struct Slot 
{
    public int row;
    public int column;
}
