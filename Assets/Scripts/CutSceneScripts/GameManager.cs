using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GameObjects1")]
    public GameObject MainPlayer;
    public GameObject MainCamera;
    public GameObject TPC;
    public GameObject AC;
    public GameObject Crosshair;
    public GameObject PlayerUI;
    public GameObject MiniMapCamera;
    public GameObject MiniMapCanvas;
    public GameObject SaveCanvas;
    public GameObject PoliceOfficers;
    public GameObject Gangsters;
    public PoliceSpawner PS;
    public Police2Spawner P2S;
    public FBIOfficer fbiS;


    [Header("GameObjects2")]
    public GameObject CutSceneTimeline;
    public GameObject PlayerCutScene;
    public GameObject Rebel1;
    public GameObject Rebel2;
    public GameObject Bus;
    public GameObject CutSceneCamera;
    public GameObject ShowPlayerCollider;
    public GameObject CutSceneEnderCollider;

    public Player player;

    private void Start()
    {
        if(MainMenu.instance.continueGame==true)
        {
            MainPlayer.SetActive(true);
            MainCamera.SetActive(true);
            TPC.SetActive(true);
            AC.SetActive(true);
            Crosshair.SetActive(true);
            PlayerUI.SetActive(true);
            MiniMapCamera.SetActive(true);
            MiniMapCanvas.SetActive(true);
            SaveCanvas.SetActive(true);
            PoliceOfficers.SetActive(true);
            Gangsters.SetActive(true);
            PS.GetComponent<PoliceSpawner>().enabled = true;
            P2S.GetComponent<Police2Spawner>().enabled = true;
            fbiS.GetComponent<FBIOfficer>().enabled = true;


            //load old data
            player.LoadPlayer();

            CutSceneTimeline.SetActive(false);
            PlayerCutScene.SetActive(false);
            Rebel1.SetActive(false);
            Rebel2.SetActive(false);
            Bus.SetActive(false);
            CutSceneCamera.SetActive(false);
            ShowPlayerCollider.SetActive(false);
            CutSceneEnderCollider.SetActive(false);
        }

        if (MainMenu.instance.startGame == true)
        {
            MainPlayer.SetActive(false);
            MainCamera.SetActive(false);
            TPC.SetActive(false);
            AC.SetActive(false);
            Crosshair.SetActive(false);
            PlayerUI.SetActive(false);
            MiniMapCamera.SetActive(false);
            MiniMapCanvas.SetActive(false);
            SaveCanvas.SetActive(false);
            PoliceOfficers.SetActive(false);
            Gangsters.SetActive(false);
            PS.GetComponent<PoliceSpawner>().enabled = false;
            P2S.GetComponent<Police2Spawner>().enabled = false;
            fbiS.GetComponent<FBIOfficer>().enabled = false;

            CutSceneTimeline.SetActive(true);
            PlayerCutScene.SetActive(false);
            Rebel1.SetActive(true);
            Rebel2.SetActive(true);
            Bus.SetActive(true);
            CutSceneCamera.SetActive(true);
            ShowPlayerCollider.SetActive(true);
            CutSceneEnderCollider.SetActive(true);
        }
    }
}
