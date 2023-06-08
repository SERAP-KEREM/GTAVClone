using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnderScript : MonoBehaviour
{
    [Header("GameObjects to Active")]
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


    [Header("GameObjects to Deactive")]
    public GameObject CutSceneTimeline;
    public GameObject PlayerCutScene;
    public GameObject Rebel1;
    public GameObject Rebel2;
    public GameObject Bus;
    public GameObject CutSceneCamera;
    public GameObject ShowPlayerCollider;
    public GameObject CutSceneEnderCollider;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "CutSceneCamera")
        {
            //Deactive Things
            CutSceneTimeline.SetActive(false);
            PlayerCutScene.SetActive(false);
            Rebel1.SetActive(false);
            Rebel2.SetActive(false);
            Bus.SetActive(false);
            CutSceneCamera.SetActive(false);
            ShowPlayerCollider.SetActive(false);
            CutSceneEnderCollider.SetActive(false);

            //Active Things
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
            PS.GetComponent<PoliceSpawner>().enabled=true;
            P2S.GetComponent<Police2Spawner>().enabled=true;
            fbiS.GetComponent<FBIOfficer>().enabled=true;
            

        }
    }



}
