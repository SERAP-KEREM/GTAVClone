using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
    public bool Mission1 = false;
    public bool Mission2 = false;
    public bool Mission3 = false;
    public bool Mission4 = false;

    public Text missionText;

    private void Update()
    {
        if( Mission1 ==false && Mission2 ==false && Mission3 == false && Mission4 == false)
        {
            //UI
            missionText.text = "Locate your house & save game.";
        }
        if (Mission1 == true && Mission2 == false && Mission3 == false && Mission4 == false)
        {
            //UI
            missionText.text = "Meet frank in police station.";
        }
        if (Mission1 == true && Mission2 == true && Mission3 == false && Mission4 == false)
        {
            //UI
            missionText.text = "Find weapons at home.";
        }
        if (Mission1 == true && Mission2 == true && Mission3 == true && Mission4 == false)
        {
            //UI
            missionText.text = "Find Gonzalves & take reverenge.";
        }
        if (Mission1 == true && Mission2 == true && Mission3 == true && Mission4 == true)
        {
            //UI
            missionText.text = "All missions completed successfully.";
        }

    }

}
