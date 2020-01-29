using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    Controller Slotcontroller;

    // Start is called before the first frame update
    void Start()
    {
      Slotcontroller.InitializeController();
    }

  
}
