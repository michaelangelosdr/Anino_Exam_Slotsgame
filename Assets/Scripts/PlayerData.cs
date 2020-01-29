using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Player Profile",menuName="Player/Player Profile")]
public class PlayerData : ScriptableObject
{
   [SerializeField]
   public string PlayerName;

   [SerializeField]
   public int PlayerCoins;

   [SerializeField]
   public int PlayerinitialCoins; 
}
