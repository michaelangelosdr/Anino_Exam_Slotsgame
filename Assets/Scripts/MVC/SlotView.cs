using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SlotView : MonoBehaviour
{

   [SerializeField]
   Image Slots_Reel_Image;
   [SerializeField]
   public GameObject[] Columns;

    [SerializeField]
    RectTransform[] ColumnsTransform;


    //Buttons
    [SerializeField]
    Button SpinButton;
    [SerializeField]
    Button IncreaseBet;
    [SerializeField]
    Button DecreaseBet;

    //Panels
    [SerializeField]
    Image WinResultPopup;

    [SerializeField]
   List<Image> LineHighlights;
    [SerializeField]
    Text Bet_Text,PlayerName,PlayerWallet,WinAmount;
    


    [SerializeField]
    private float IconSize = 300;



    public void AttachIncreaseBetListener(UnityAction action)
    {
        IncreaseBet.onClick.AddListener(action);
    }

     public void AttachDecreaseBetListener(UnityAction action)
    {
        DecreaseBet.onClick.AddListener(action);
    }

    public void AttachSpinButtonListener(UnityAction action)
    {
        SpinButton.onClick.AddListener(action);
    }

    public void SetPlayerData(string p_name)
    {
        PlayerName.text = p_name;
    }

    public void SetPlayerBalance(int playerbalance)
    {
        PlayerWallet.text = "coins: " +playerbalance.ToString();
    }
    public void SetPlayerBet(int Bet)
    {
        Bet_Text.text = "Bet: "+Bet.ToString();
    }

    private int[] CurrentRowOffset;
    public void ChangeReelPosition(float y)
    {
        float ColX = ColumnsTransform[0].anchoredPosition.x;
         float ColY = ColumnsTransform[0].anchoredPosition.y;
       

        Debug.Log(ColumnsTransform[0].anchoredPosition);
        ColY += (IconSize*y);
        ColumnsTransform[0].anchoredPosition += new Vector2(0,ColY);
    }
    public void ChangeReelPosition(int row_Index,float LineOffset)
    {float ColX = ColumnsTransform[row_Index].anchoredPosition.x;
        float ColY = ColumnsTransform[row_Index].anchoredPosition.y;
        ColY = (IconSize*LineOffset);
        ColumnsTransform[row_Index].anchoredPosition = new Vector2(ColX,ColY);
    }

 

    public void ChangeReelPosition(int[] LineOffset)
    {
        for(int x=0; x<Columns.Length;x++)
        {
            
        float ColX = ColumnsTransform[x].anchoredPosition.x;
         float ColY = ColumnsTransform[x].anchoredPosition.y;
       
        ColY += (IconSize*LineOffset[x]);
        ColumnsTransform[x].anchoredPosition += new Vector2(0,ColY);
        }
    }
     public void ChangeReelPosition(int[] LineOffset,UnityAction<int[]> action)
    {
        CurrentRowOffset = new int[Columns.Length];
        for(int x=0; x<Columns.Length;x++)
        {            
        CurrentRowOffset[x] = LineOffset[x];
        float ColX = ColumnsTransform[x].anchoredPosition.x;
        float ColY = ColumnsTransform[x].anchoredPosition.y;
       
        ColY =(IconSize*LineOffset[x]);
        ColumnsTransform[x].anchoredPosition = new Vector2(ColX,ColY);
        }
         action(CurrentRowOffset);
    }

        public void ChangeReelPosition(int row_Index,int LineOffset,UnityAction<int> action)
    {
        float ColX = ColumnsTransform[row_Index].anchoredPosition.x;
        float ColY = ColumnsTransform[row_Index].anchoredPosition.y;
        ColY = (IconSize*LineOffset);
        ColumnsTransform[row_Index].anchoredPosition = new Vector2(ColX,ColY);

        action(LineOffset);
    }

    public void ShowWinAnimation(int amount)
    {
        StartCoroutine(ShowWinScreen(amount));
    }

    private IEnumerator ShowWinScreen(int winAmount)
    {
        WinResultPopup.gameObject.SetActive(true);
        WinAmount.text = winAmount.ToString();
        yield return new WaitForSeconds(2);
        WinResultPopup.gameObject.SetActive(false);
        WinAmount.text = winAmount.ToString();
        yield return null;
    }

    public void HighlightSymbols(int LineType)
    {
        LineHighlights[LineType].gameObject.SetActive(true);
    }
    public void HideHighlights()
    {
        foreach(Image i in LineHighlights)
        {
            i.gameObject.SetActive(false);
        }
    }

   
}
