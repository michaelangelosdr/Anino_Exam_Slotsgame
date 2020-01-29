using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animation))]
public class SlotSymbol : MonoBehaviour
{
   [SerializeField]
   public Image IconImage;

   [SerializeField]
    public Animation WinAnimation;

    [SerializeField]
    public string Name;

    [SerializeField]
    public SymbolID ID;

}

public enum SymbolID
{
    ACE= 0,
    JACK = 1,
    QUEEN =2,
    KING = 3,
    THEME1 =4,
    THEME2=5,
    THEME3=6,
    THEME4=7
}
