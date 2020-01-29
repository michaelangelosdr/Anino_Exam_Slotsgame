﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="PAR",menuName="GameMath")]
public class SlotSymbolPositions: ScriptableObject
{
    public int[,] SlotGamePositions = {{0,1,2,3,4,5,6,7,0,2,3,4,5,0,1,2,3,4,5,6,7,0,2,3,5,5,0,1,2,3,4,5,6,7,0,2,3,4,5,0,1,2,3,4,5,6,7,0,2,3,4,5},
                                        {0,1,2,3,4,5,6,7,0,2,3,4,5,0,1,2,5,5,5,6,7,0,7,7,7,5,0,1,2,5,5,5,6,7,0,2,3,4,5,5,1,2,3,4,5,6,4,5,6,6,7,7},
                                        {0,1,2,3,4,5,6,7,0,2,3,4,5,0,1,2,3,4,5,6,7,7,7,3,4,5,0,1,2,5,5,5,6,7,0,2,3,5,5,2,2,3,3,4,4,4,5,5,6,6,7,7}};
    public int [] InitialPosition = {3,7,10};
}
