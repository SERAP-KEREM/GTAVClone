using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission2 : MonoBehaviour
{
    public Player player;
    public Missions missions;

    public Text missionCompletedText;
    public GameObject SaveUIgameObject;


    private void OnTriggerEnter(Collider other)
    {
      
       
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Mission2UI());
            if (missions.Mission1 == true && missions.Mission3 == false && missions.Mission4 == false)
            {
                missionCompletedText.text = "You have completed your mission to meet Frank.";

                missions.Mission2 = true;
                player.playerMoney += 600;
                Debug.Log(missionCompletedText);

            }

        }
    }

    IEnumerator Mission2UI()
    {
        SaveUIgameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SaveUIgameObject.SetActive(false);
    }
}
