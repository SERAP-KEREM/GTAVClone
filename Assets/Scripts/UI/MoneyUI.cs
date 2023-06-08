using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Player player;
    public Text MoneyAmountText;

    private void Update()
    {
        MoneyAmountText.text = "" + player.playerMoney;
    }

}
