using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
public class Controller : MonoBehaviour
{
    [SerializeField]
    SlotView slotView;

    [SerializeField]
    SlotModel slotModel;

    private bool IsSpinning;

    private PlayerData p_data;
    private SessionDataValues SessionValues;
    private SlotDataset dataset;
    public void InitializeController()
    {
        slotModel.values = new SessionDataValues();
        SessionValues = slotModel.values;
        p_data = slotModel.p_data;
        dataset = slotModel.dataset;
        
        PopulateReels();
        SetInitialPosition();      
        //CheckReelMatrix();  

       
       //set initial bet
        SessionValues.TotalBet =1;
        slotView.AttachSpinButtonListener(()=>{Spin();});
        slotView.AttachIncreaseBetListener(()=>{IncreaseBet();});
        slotView.AttachDecreaseBetListener(()=>{DecreaseBet();});
        slotView.SetPlayerData(p_data.PlayerName);
        slotView.SetPlayerBalance(p_data.PlayerCoins);
        slotView.SetPlayerBet(SessionValues.TotalBet);
        slotView.HideHighlights();
    }

    private void IncreaseBet()
    {
        
          if(SessionValues.TotalBet <10) //Should be MAX_BET Change during Refactor
          {
              SessionValues.TotalBet+=1;
          }
          slotView.SetPlayerBet(SessionValues.TotalBet);
    }

    private void DecreaseBet()
    {
        
          if(SessionValues.TotalBet >1) //Should be MAX_BET Change during Refactor
          {
              SessionValues.TotalBet-=1;
          }
           slotView.SetPlayerBet(SessionValues.TotalBet);
    }

    private void PopulateReels()
    {
        //Get data
        SlotSymbolPositions slotpos = slotModel.dataset.PARSHEET;
        int rowCount = slotpos.SlotGamePositions.GetLength(0);
        int colCount = slotpos.SlotGamePositions.GetLength(1);
        dataset.SlotRows = rowCount;
        dataset.SlotColumns = colCount;
        SessionValues.ReelDatasets = new SlotSymbol[rowCount,colCount];
        for(int row = 0; row<rowCount; row++)
        {
            for(int col=0;col<colCount;col++)
            {
                int SlotSymbolIndex = col;
                if(SlotSymbolIndex>=dataset.SlotSymbolsList.Count)
                {                   
                  int countmultiplier = col/dataset.SlotSymbolsList.Count;               
                  SlotSymbolIndex -= dataset.SlotSymbolsList.Count*countmultiplier;
                }
                SlotSymbol _symbol = Instantiate(dataset.SlotSymbolsList[SlotSymbolIndex],slotView.Columns[row].transform);
                SessionValues.ReelDatasets[row,col] = _symbol;        
            }
        }       
    }

    public void SetInitialPosition()
    {
        SlotSymbolPositions s = slotModel.dataset.PARSHEET;
        slotView.ChangeReelPosition(s.InitialPosition,
        (int[] symbolOffset) => {          
           SessionValues.UpdateMatrix(symbolOffset);
        }
        
        ); 
    }

    public void CheckReelMatrix()
    {
        foreach(LineWin slot in dataset.LineSetup)
        {
            int[,] WinLine = slot.Line();
            bool IsWinningLine = true;
            //get the first symbol
            int SymbolValue = SessionValues.ReelLineMatrix[WinLine[0,0],WinLine[0,1]];
            for(int x=0; x<WinLine.GetLength(0);x++)
            {
                if(SymbolValue != SessionValues.ReelLineMatrix[WinLine[x,0],WinLine[x,1]])
                {
                    IsWinningLine = false;
                    break;
                }
            }
            if(IsWinningLine)
            {
                AddWins(SymbolValue,slot);
            }

        }

        CashoutTotalWin();


    }


    public void AddWins(int SymbolValue,LineWin WinningLine)
    {
       
        int AmountWon = SymbolValue+1;

        SessionValues.WinningLines.Add(WinningLine);    
        SessionValues.TotalAmountWon +=AmountWon * SessionValues.TotalBet; //Needs to be multiplied with Player bet
    }
    public void CashoutTotalWin()
    {
        Debug.Log(SessionValues.TotalAmountWon);
        p_data.PlayerCoins+=SessionValues.TotalAmountWon;

        if(SessionValues.TotalAmountWon>0)
        {slotView.ShowWinAnimation(SessionValues.TotalAmountWon);
        foreach(LineWin l in SessionValues.WinningLines)
        {
            slotView.HighlightSymbols(l.GetLineType());
        }
        }

        SessionValues.RefreshWinnings();
        slotView.SetPlayerBalance(p_data.PlayerCoins);
        //Add to player bet 
    }

    public void Spin()
    {
      
        int RoundBet = SessionValues.TotalBet *  slotModel.dataset.LineSetup.Count;

        if(p_data.PlayerCoins>=RoundBet)
        {
        if(!IsSpinning)
        {
    
        p_data.PlayerCoins -= RoundBet;
        
        slotView.SetPlayerBalance(p_data.PlayerCoins);
        slotView.HideHighlights();
        StartCoroutine(SpinAnimation());
        //StartCoroutine(TestSpin());
        IsSpinning = true;
        }
        }
    }   
    
     public void Test_Spin_AllLines()
    {
      
        int RoundBet = SessionValues.TotalBet *  slotModel.dataset.LineSetup.Count;

        if(p_data.PlayerCoins>=RoundBet)
        {
        if(!IsSpinning)
        {
    
        p_data.PlayerCoins -= RoundBet;
        
        slotView.SetPlayerBalance(p_data.PlayerCoins);
        slotView.HideHighlights();
        int[] test = {0,0,0};
        StartCoroutine(TestSpin(test));
        IsSpinning = true;
        }
        }
    }  

    




    public IEnumerator SpinAnimation()
    {
        int[] Offset = new int[3];

            for(int x=0; x<Offset.Length;x++)
            {
            Offset[x] = Random.Range(0,SessionValues.ReelDatasets.GetLength(1)-2);
            StartCoroutine(SpinSingleReel(x,Offset[x]));
            yield return new WaitForSeconds(0.5f);
            }
            SessionValues.UpdateMatrix(Offset);
            //Waits for a second to show win
        yield return new WaitForSeconds(2);
         CheckReelMatrix();
        IsSpinning =false;
    }


    public IEnumerator TestSpin(int[] t)
    {

        int[] Offset = t;

            for(int x=0; x<Offset.Length;x++)
            {
            //Offset[x] = Random.Range(0,SessionValues.ReelDatasets.GetLength(1)-2);
            
            StartCoroutine(SpinSingleReel(x,Offset[x]));
            yield return new WaitForSeconds(0.5f);
            }
            SessionValues.UpdateMatrix(Offset);
           
            //Waits for a second to show win
        yield return new WaitForSeconds(2);
         CheckReelMatrix();
        IsSpinning =false;
    }



    public IEnumerator SpinSingleReel(int ReelIndex,int EndIndex)
    {
        float CurrentTime = 0;
        SessionDataValues SessionValues = slotModel.values;
        int Offset = Random.Range(0,SessionValues.ReelDatasets.GetLength(1)-2);
        while(CurrentTime<SessionValues.SpinTimeAnimation/2)
        {
            CurrentTime+=Time.deltaTime;
            Offset = Random.Range(0,SessionValues.ReelDatasets.GetLength(1)-2);
            slotView.ChangeReelPosition(ReelIndex,Offset);
            //delay
            yield return new WaitForSeconds(0.055f);
        }
         slotView.ChangeReelPosition(ReelIndex,EndIndex);
        yield return null;
    }

    public void AddCash()
    {
        p_data.PlayerCoins+=100;
        slotView.SetPlayerBalance(p_data.PlayerCoins);
    }
}
