using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
   [SerializeField]
   SlotDataset Reel_slotdataset;

    //For Testing purposes
    [SerializeField]
    SlotSymbol[,] ReelSet;

   public void CheckDataset()
   {
        if(Reel_slotdataset)
        {
              return;
        }
        InitializeReelset();
   }

    public void InitializeReelset()
    {
        ReelSet = new SlotSymbol[Reel_slotdataset.SlotRows,Reel_slotdataset.SlotColumns];
        RandomizeReelset();
    }

    public void RandomizeReelset()
    {
         for(int x=0;x<Reel_slotdataset.SlotRows;x++)
        {
            for(int i =0; i<Reel_slotdataset.SlotColumns;i++)
            {
                //ReelSet[x,i] = Reel_slotdataset.SlotSymbolsList[i];
            }
        }
    }
}
