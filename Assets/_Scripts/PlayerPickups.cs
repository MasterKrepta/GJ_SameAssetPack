using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickups : MonoBehaviour
{
    public int TotalCoins;
    public Text CoinUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetCoin(int value)
    {
        TotalCoins += value;
        CoinUI.text = TotalCoins.ToString();
    }
}
