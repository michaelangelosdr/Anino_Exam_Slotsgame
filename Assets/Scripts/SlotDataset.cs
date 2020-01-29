using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dataset",menuName="Slots settings/dataset")]
public class SlotDataset : ScriptableObject
{
    [SerializeField]
    public List<SlotSymbol> SlotSymbolsList;
    
    [SerializeField]
    public List<LineWin> LineSetup;

    [SerializeField]
    public int SlotRows,SlotColumns;

    [SerializeField]
    public string SlotMachineName;

    [SerializeField]
    public SlotSymbolPositions PARSHEET;

    
}


