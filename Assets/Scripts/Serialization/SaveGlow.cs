using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class SaveGlow : MonoBehaviour
{
    public Player player;
    public Missions missions;

    public Text missionCompletedText;
    public GameObject SaveUIgameObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            player.SavePlayer();
            StartCoroutine(SaveUI());
           
        }
        if(missions.Mission2 ==false && missions.Mission3 ==false && missions.Mission4==false)
        {
            missions.Mission1 = true;
            player.playerMoney += 400;
            missionCompletedText.text = "You game has been saved.";
        }
    }

    IEnumerator SaveUI()
    {
        SaveUIgameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SaveUIgameObject.SetActive(false);
    }
}
